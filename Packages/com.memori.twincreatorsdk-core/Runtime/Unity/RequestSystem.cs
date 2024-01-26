using System;
using UnityEngine;
using UnityEngine.Networking;

namespace TwinCreator.Core.Unity
{
    /// <summary>
    /// Questa classe richiama i metodi della webclass
    /// </summary>
    /// 
    public class RequestSystem : MonoBehaviour
    {
        public WebClass WEB;

        public enum Operation
        {
            GET,
            POST,
            DELETE,
        }

        /// <summary>
        /// Send a request 
        /// </summary>
        /// <param name="operation"> TypeRequest.(GET,PUT,DELETE,POST) </param>
        /// <param name="url">Url to connect</param>
        /// <returns>Returns a Unity web request.</returns>
        public void SendRequest(Operation operation, string url, Action<UnityWebRequest> callback)
        {
            switch (operation)
            {
                // GET 
                case Operation.GET:
                    StartCoroutine(WEB.GetRequest(url, value => { callback.Invoke(value); }));
                    break;
            }
        }

        /// <summary>
        /// Send a request 
        /// </summary>
        /// <param name="operation"> TypeRequest.(GET,PUT,DELETE,POST) </param>
        /// <param name="url">Url to connect</param>
        /// <param name="json"> json file </param>
        /// <returns>Returns a Unity web request.</returns>
        public void SendRequest(Operation operation, string url, string json, Action<UnityWebRequest> callback)
        {
            switch (operation)
            {
                case Operation.POST:
                    StartCoroutine(WEB.PostRequest(url, json, value => { callback.Invoke(value); }));
                    break;

                case Operation.DELETE:
                    StartCoroutine(WEB.DeleteRequest(url, json, value => { callback.Invoke(value); }));
                    break;


            }
        }
    }
}