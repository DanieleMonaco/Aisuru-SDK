using Newtonsoft.Json;
using System;
using UnityEngine;

namespace TwinCreator.Core.Unity
{
    /// <summary>
    /// This class contains all methods for managing server-side memories
    /// </summary>
    public class MemoriAPIMethods : MonoBehaviour
    {
        public ServerData ServerData;
        public RequestSystem RequestMethods;

        /// <summary>
        /// Deserializable file json to memori
        /// </summary>
        /// <param name="json"> json that contains memori information </param>
        /// <returns> MemoriAPI.Root</returns>
        MemoriAPI.Root DeserializeMemori(string json)
        {
            return JsonConvert.DeserializeObject<MemoriAPI.Root>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        /// <summary>
        /// Get memori by NAME
        /// </summary>
        /// <param name="postMemori"> object container of informations memori</param>
        /// <returns>MemoriAPI.Root</returns>
        public void GetMemori(MemoriAPI.PostMemoriName postMemori, Action<MemoriAPI.Root> callback = null)
        {
            MemoriAPI.Root memori = null;
            string uri = ServerData.MemoriNameURL + "/" + postMemori.tenantName + "/" + postMemori.userName + "/" + postMemori.memoriName;
#if DEBUG_LOG
            Debug.Log(uri);
#endif
            RequestMethods.SendRequest(RequestSystem.Operation.GET, uri, value =>
            {
                memori = DeserializeMemori(value.downloadHandler.text);
#if DEBUG_LOG
                Debug.Log("MEMORI: " + value.downloadHandler.text);
#endif
                callback.Invoke(memori);
            });
            
        }
        /// <summary>
        /// Get memori by ID
        /// </summary>
        /// <param name="postMemori"> object container of informations memori</param>
        /// <returns>MemoriAPI.Root</returns>
        public void GetMemori(MemoriAPI.PostMemoriID postMemori, Action<MemoriAPI.Root> callback = null)
        {
            MemoriAPI.Root memori = null;

            string uri = ServerData.MemoriIDURL + "/" + postMemori.tenantName + "/" + postMemori.strUserID + "/" + postMemori.strMemoriID;
            if (postMemori.strToken != "null")
                uri += "/{strToken}?strToken=" + postMemori.strToken;
#if DEBUG_LOG
            Debug.Log(uri);
#endif
            RequestMethods.SendRequest(RequestSystem.Operation.GET, uri, value =>
            {
                memori = DeserializeMemori(value.downloadHandler.text);
#if DEBUG_LOG
                Debug.Log("MEMORI: " + value.downloadHandler.text);
#endif
                callback.Invoke(memori);
            });

        }

    }
}





