using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwinCreator.Core;
using TwinCreator.Core.Unity;
using UnityEngine.Events;

public class SDKTest : MonoBehaviour
{
    public Memori TwinDesc;
    public SessionAPIMethods SessionApi;
    public DialogueAPIMethods DialogueApi;
    public MemoriAPIMethods MemoriApi;
    public ServerData ServerData;
    public string Question;
    public string Language;
    public UnityEvent OnSessionOpened;
    public UnityEvent<string> OnResponseGiven;
    public UnityEvent<string> OnMediaReceived;
    public UnityEvent OnSessionClosed;
    private SessionAPI.Root currentSession;
    private MemoriAPI.Root currentMemori;

    #region Callbacks

    public void Log(string logMessage)
    {
        Debug.Log(logMessage);
    }

    public void ShowMedia(string url)
    {
        Application.OpenURL(url);
    }
    

    #endregion

    private void Awake()
    {
        currentSession = null;
    }

    public bool IsSessionOpen
    {
        get
        {
            return currentSession != null;
        }
    }

    void OpenSession_Translated(SessionAPI.RequestSession sessionRequest)
    {
        DialogueApi.TranslationDialog(sessionRequest.initialQuestion, currentMemori.memori.culture, Language, translatedQuestion =>
        {
            sessionRequest.initialQuestion = translatedQuestion;
            SessionApi.SessionPost(sessionRequest, jsonResponse =>
            {
                if (jsonResponse != "404" && jsonResponse != "422")
                {
                    OnSessionOpened.Invoke();
                    currentSession = SessionApi.DeserializeSessionPost(jsonResponse);
                    DialogueApi.TranslationDialog(currentSession.currentState.emission, Language, currentMemori.memori.culture, translatedResponse =>
                    {
                        currentSession.currentState.emission = translatedResponse;
                        OnResponseGiven.Invoke(translatedResponse);
                    });
                }
            });
        });
    }

    public void OpenSession(string initialQuestion, Dictionary<string, string> context = null)
    {
        MemoriAPI.PostMemoriID postMemori = new MemoriAPI.PostMemoriID()
        {
            strMemoriID = TwinDesc.IDMemori,
            strToken = TwinDesc.token,
            tenantName = ServerData.tenantName,
            strUserID = ServerData.ownerID
        };

        if(context == null)
        {
            context = new Dictionary<string, string> { };
        }

        MemoriApi.GetMemori(postMemori, twin =>
        {
           currentMemori = twin;
           SessionAPI.RequestSession postSession = new()
           {
               memoriID = TwinDesc.IDEngineMemori,
               password = TwinDesc.PasswordMemori,
               birthDate = new DateTime(2001, 1, 1),
               initialQuestion = initialQuestion,
               initialContextVars = context
           };

           if (Language != currentMemori.memori.culture)
           {
               OpenSession_Translated(postSession);
           }
           else
           {
               SessionApi.SessionPost(postSession, jsonResponse =>
               {
                   if (jsonResponse != "404" && jsonResponse != "422")
                   {
                       OnSessionOpened.Invoke();
                       currentSession = SessionApi.DeserializeSessionPost(jsonResponse);
                       OnResponseGiven.Invoke(currentSession.currentState.emission);
                   }
               });
           }
        });
    }

    void SendTranslatedRequest(string question)
    {
        DialogueApi.TranslationDialog(question, currentMemori.memori.culture, Language, translatedQuestion =>
        {
            DialogueApi.DialogueSendRequest(translatedQuestion, currentSession.sessionID, response =>
            {
                DialogueApi.TranslationDialog(response.currentState.emission, Language, currentMemori.memori.culture, translatedResponse =>
                {
                    OnResponseGiven.Invoke(translatedResponse);
                    if (response.currentState.media.Count > 0)
                    {
                        foreach (var curMedia in response.currentState.media)
                        {
                            OnMediaReceived.Invoke(curMedia.url + "/" + currentSession.sessionID);
                        }
                    }
                });
            });
        });
    }

    public void SendRequest(string question)
    {
        if (currentSession != null)
        {
            string finalQuestion = question;
            if (Language != currentMemori.memori.culture)
            {
                SendTranslatedRequest(question);
            }
            else
            {
                DialogueApi.DialogueSendRequest(finalQuestion, currentSession.sessionID, response =>
                {
                    OnResponseGiven.Invoke(response.currentState.emission);
                    if (response.currentState.media.Count > 0)
                    {
                        OnMediaReceived.Invoke(response.currentState.media[0].url + "/" + currentSession.sessionID);
                    }
                });
            }
        }
    }

    public void CloseCurrentSession()
    {
        if (currentSession != null)
        {
            SessionAPI.DeleteSession deleteSession = new()
            {
                requestID = currentSession.requestID,
                requestDateTime = currentSession.requestDateTime,
                resultCode = currentSession.resultCode,
                resultMessage = currentSession.resultMessage
            };
            
            SessionApi.DeleteSession(deleteSession, currentSession.sessionID);
            OnSessionClosed.Invoke();
            currentSession = null;
        }
    }

    [ContextMenu("Open")]
    void OpenSession()
    {
        OpenSession(Question);
    }
    
    [ContextMenu("Talk")]
    void SendRequest()
    {
        SendRequest(Question);
    }
    
    [ContextMenu("Close")]
    void CloseSession()
    {
        CloseCurrentSession();
    }
}
