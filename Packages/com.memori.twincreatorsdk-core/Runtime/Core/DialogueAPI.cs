using System;
using System.Collections.Generic;

namespace TwinCreator.Core
{
    public class DialogueAPI
    {
        [Serializable]
        public class DialoguePost
        {
            public string text { get; set; }
        }

        [Serializable]
        public class CurrentState
        {
            public string state { get; set; }
            public string stateName { get; set; }
            public string previousState { get; set; }
            public double confidence { get; set; }
            public string emission { get; set; }
            public bool continuationEmitted { get; set; }
            public bool acceptsTimeout { get; set; }
            public bool acceptsAbort { get; set; }
            public bool acceptsMedia { get; set; }
            public bool acceptsDate { get; set; }
            public bool acceptsPlace { get; set; }
            public bool acceptsTag { get; set; }
            public List<string> hints { get; set; }
            public string currentTag { get; set; }
            public string currentDate { get; set; }
            public string currentPlaceName { get; set; }
            public string currentLatitude { get; set; }
            public string currentLongitude { get; set; }
            public string currentUncertaintyKm { get; set; }
            public string giverID { get; set; }
            public string currentReceiverID { get; set; }
            public string currentMemoryID { get; set; }
            public List<MemoriesAPI.Medium> media { get; set; }
            public Dictionary<string, string> knownTags { get; set; }
            public Dictionary<string, string> contextVars { get; set; }
        }

        [Serializable]
        public class Root
        {
            public CurrentState currentState { get; set; }
            public int requestID { get; set; }
            public DateTime requestDateTime { get; set; }
            public int resultCode { get; set; }
            public string resultMessage { get; set; }
            public string questionEmission { get; set; }
            public InstancedMemori dataMemori { get; set; }
        }
    }
}