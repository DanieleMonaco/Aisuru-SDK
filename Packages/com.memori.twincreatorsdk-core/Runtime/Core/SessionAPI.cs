using System;
using System.Collections.Generic;

namespace TwinCreator.Core
{
    public class SessionAPI
    {
        [Serializable]
        public class Root
        {
            public string sessionID { get; set; }
            public CurrentState currentState { get; set; }
            public int requestID { get; set; }
            public DateTime requestDateTime { get; set; }
            public int resultCode { get; set; }
            public string resultMessage { get; set; }
        }

        [Serializable]
        public class CurrentState
        {
            public string state { get; set; }
            public string stateName { get; set; }
            public string previousState { get; set; }
            public object confidence { get; set; }
            public string emission { get; set; }
            public bool acceptsTimeout { get; set; }
            public bool acceptsAbort { get; set; }
            public bool acceptsMedia { get; set; }
            public bool acceptsDate { get; set; }
            public bool acceptsPlace { get; set; }
            public bool acceptsTag { get; set; }
            public List<string> hints { get; set; }
            public object currentTag { get; set; }
            public object currentDate { get; set; }
            public object currentPlaceName { get; set; }
            public object currentLatitude { get; set; }
            public object currentLongitude { get; set; }
            public object currentUncertaintyKm { get; set; }
            public string giverID { get; set; }
            public object currentReceiverID { get; set; }
            public object currentMemoryID { get; set; }
            public List<MemoriesAPI.Medium> media { get; set; }
            public Dictionary<string, string> knownTags { get; set; }
            public Dictionary<string, string> initialContextVars { get; set; }
        }

        [Serializable]
        public class RequestSession
        {
            public string memoriID { get; set; }
            public string password { get; set; }
            public string[] recoveryTokens { get; set; }
            public string tag { get; set; }
            public string pin { get; set; }
            public Dictionary<string, string> initialContextVars { get; set; }
            public string initialQuestion { get; set; }
            public DateTime birthDate { get; set; }
        }

        [Serializable]
        public class DeleteSession
        {
            public int requestID { get; set; }
            public DateTime requestDateTime { get; set; }
            public int resultCode { get; set; }
            public string resultMessage { get; set; }
        }


    }
}




