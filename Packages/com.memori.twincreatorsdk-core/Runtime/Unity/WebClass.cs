using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace TwinCreator.Core.Unity
{
    /// <summary>
    /// this class sends get, post, and delete requests to the server
    /// </summary>
    public class WebClass : MonoBehaviour
    {
        /// <summary>
        /// Send GET request to server
        /// </summary>
        /// <param name="url">uri</param>
        /// <param name="callback">param to return</param>
        /// <returns>callback: UnityWebRequest</returns>
        public IEnumerator GetRequest(string url, Action<UnityWebRequest> callback = null)
        {
            using UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;
            switch (request.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError("connection error: " + request.error);
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error GET : " + request.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": Error GET : " + request.error);
                    break;
                case UnityWebRequest.Result.Success:
                    callback?.Invoke(request);
                    break;
            }
        }

        /// <summary>
        /// Send POST request to server
        /// </summary>
        /// <param name="url">uri</param>
        /// <param name="json">json</param>
        /// <param name="callback">param to return</param>
        /// <returns>callback: UnityWebRequest</returns>
        public IEnumerator PostRequest(string url, string json, Action<UnityWebRequest> callback = null)
        {
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            callback?.Invoke(request);
        }

        /// <summary>
        /// Send DELETE request to server
        /// </summary>
        /// <param name="url">uri</param>
        /// <param name="json">json</param>
        /// <param name="callback">param to return</param>
        /// <returns>callback: UnityWebRequest</returns>
        public IEnumerator DeleteRequest(string url, string json, Action<UnityWebRequest> callback = null)
        {
            var request = new UnityWebRequest(url, "DELETE");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            callback?.Invoke(request);
        }

        public void GetTexture(string url, Action<Texture2D> callback = null)
        {
            GetTextureCustom(url, "256", "256", callback);
        }

        public void GetTextureCustom(string url, string width, string height, Action<Texture2D> callback = null)
        {
            StartCoroutine(GetTextureCustomInternal(url, width, height, callback));
        }

        IEnumerator GetTextureCustomInternal(string url, string width, string height, Action<Texture2D> callback = null)
        {
            string spriteURL = "https://app.twincreator.com/api/imgresize/" + width + "/" + height + "/";
            string urlEncoded = UnityWebRequest.EscapeURL(url);
            spriteURL += urlEncoded;
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(spriteURL);
            yield return www.SendWebRequest();
            Texture2D loadedTexture = DownloadHandlerTexture.GetContent(www);
            callback?.Invoke(loadedTexture);
        }

    }

}