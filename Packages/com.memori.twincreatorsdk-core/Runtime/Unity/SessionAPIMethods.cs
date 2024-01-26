using Newtonsoft.Json;
using System;
using UnityEngine;

namespace TwinCreator.Core.Unity
{
    /// <summary>
    /// Class contains  all methods related to sending, opening and closing the session with a memori.
    /// </summary>
    public class SessionAPIMethods : MonoBehaviour
    {
        public ServerData ServerData;
        public RequestSystem RequestMethods;
        
        /// <summary>
        ///sending information for the session
        /// </summary>
        /// <param name="postSession"> information for create file json to send </param>
        /// <param name="callback"> Action bool </param>
        /// <returns> whether the session was opened successfully or not</returns>
        public void SessionPost(SessionAPI.RequestSession postSession, Action<string> callback)
        {
            string sessionInformation = null;
            string json = JsonConvert.SerializeObject(postSession);
            long responseCode = 0;
            RequestMethods.SendRequest(RequestSystem.Operation.POST,
                ServerData.SessionURL, json, value =>
                {
                    //if (value.responseCode == 200)
                    responseCode = value.responseCode;
                    sessionInformation = value.downloadHandler.text;
#if DEBUG_LOG
                    Debug.Log("SESSION: " + responseCode + " " + value.downloadHandler.text);
#endif
                    if (responseCode == 200) //open
                    {
                        DeserializeSessionPost(sessionInformation);
                        callback.Invoke(sessionInformation);
                    }
                    else if (responseCode == 422 || responseCode == 403)
                    {
                        callback.Invoke("422"); //insert password
                    }
                    else
                    {
                        callback.Invoke("404"); // error
                    }
                });


            
        }

        /// <summary>
        /// closing of the session
        /// </summary>    
        /// <param name="deleteSession"> obj request</param>
        /// <param name="sessionID"> session ID</param>
        public void DeleteSession(SessionAPI.DeleteSession deleteSession, string sessionID)
        {
            string json = JsonConvert.SerializeObject(deleteSession);
            string url = ServerData.SessionURL + "/" + sessionID;
            RequestMethods.SendRequest(RequestSystem.Operation.DELETE, url, json, _ => { });
        }

        /// <summary>
        /// Deserializable json Session
        /// </summary>
        /// <param name="json">Sting json </param>
        public SessionAPI.Root DeserializeSessionPost(string json)
        {
            return JsonConvert.DeserializeObject<SessionAPI.Root>(json,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }


    }
}