using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using UnityEngine;

namespace TwinCreator.Core.Unity
{
    public class MetaverseAPIMethods : MonoBehaviour
    {
        public ServerData ServerData;
        public RequestSystem RequestMethods;

        public void GetSpace(string idSpace, Action<MetaverseAPI.Space> callback = null)
        {
            MetaverseAPI.Space space;
            string uri = ServerData.MetaverseGetSpaceURL + "/" + idSpace;
#if DEBUG_LOG
            Debug.Log(uri);
#endif
            RequestMethods.SendRequest(RequestSystem.Operation.GET, uri, value =>
            {
                space = DeserializeSpace(value.downloadHandler.text);
#if DEBUG_LOG
                Debug.Log("SPACE: " + value.downloadHandler.text);
#endif
                callback?.Invoke(space);
            });

        }
        
        public MetaverseAPI.Space DeserializeSpace(string json)
        {
            return JsonConvert.DeserializeObject<MetaverseAPI.Space>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
