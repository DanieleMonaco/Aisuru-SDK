using Newtonsoft.Json;
using System;
using UnityEngine;

namespace TwinCreator.Core.Unity
{
    /// <summary>
    /// This class handles all dialogue and translation requests between player and memory
    /// </summary>
    public class DialogueAPIMethods : MonoBehaviour
    {
        public ServerData serverData;
        public RequestSystem requestMethods;

        /// <summary>
        /// Send request text for dialogue to server
        /// <param name="dialogue">text of dialogue</param>
        /// <param name="sessionID">session ID of memori </param>
        /// <returns> DialogueAPI.Root </returns>
        /// </summary>
        public void DialogueSendRequest(string dialogue, string sessionID, Action<DialogueAPI.Root> callback)
        {
            DialogueAPI.Root dialogueInformation;
            DialogueAPI.DialoguePost postData = new()
            {
                text = dialogue
            };

            string json = JsonConvert.SerializeObject(postData);
            string url = serverData.DialogueURL + sessionID;

            requestMethods.SendRequest(RequestSystem.Operation.POST, url, json, value =>
            {
#if DEBUG_LOG
                Debug.Log(value.downloadHandler.text);
#endif
                dialogueInformation = DeserializeDialogue(value.downloadHandler.text);
                callback.Invoke(dialogueInformation);
            });

        }

        /// <summary>
        /// translating a text 
        /// <param name="text">dialogue of translate</param>
        /// <param name="target">target translate</param>
        /// <param name="source">source translate</param>
        /// <returns> TranslateAPI.Root </returns>
        /// </summary>
        public void TranslationDialog(string text, string target, string source, Action<string> callback)
        {
            TranslateAPI.Root resultTranslate = null;

            string[] t = target.Split("-");
            string[] s = source.Split("-");

            TranslateAPI.TranslateInformation query = new()
            {
                text = text,
                source_lang = s[0],
                target_lang = t[0]
            };

            UriBuilder uri = new(serverData.TranslateURL);
            uri.Query += "?text=" + query.text;
            uri.Query += "&target_lang=" + query.target_lang;
            uri.Query += "&source_lang=" + query.source_lang;

            requestMethods.SendRequest(RequestSystem.Operation.GET, uri.ToString(), value =>
            {
                resultTranslate = DeserializeTranslate(value.downloadHandler.text);
                string textResult = resultTranslate.translations[0].text;
                resultTranslate.translations.Remove(resultTranslate.translations[0]);
                callback.Invoke(textResult);
            });
        }

        /// <summary>
        /// Deserializable file json to dialog response
        /// </summary>
        /// <param name="json"> json that contains dialog information </param>
        /// <returns> DialogueAPI.Root </returns>
        private DialogueAPI.Root DeserializeDialogue(string json)
        {
            return JsonConvert.DeserializeObject<DialogueAPI.Root>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        /// <summary>
        /// Deserializable file json to translate response
        /// </summary>
        /// <param name="json"> json that contains dialog information </param>
        /// <returns> TranslateAPI.Root </returns>
        private TranslateAPI.Root DeserializeTranslate(string json)
        {
            return JsonConvert.DeserializeObject<TranslateAPI.Root>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

    }

}
