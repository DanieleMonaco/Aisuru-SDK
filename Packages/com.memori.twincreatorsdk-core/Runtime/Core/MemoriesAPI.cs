using System;
using System.Collections.Generic;

namespace TwinCreator.Core
{
    public class MemoriesAPI
    {
        [Serializable]
        public class Root
        {
            public Memory memory { get; set; }
            public int requestID { get; set; }
            public DateTime requestDateTime { get; set; }
            public int resultCode { get; set; }
            public string resultMessage { get; set; }
        }

        [Serializable]
        public class Answer
        {
            public string text { get; set; }
            public bool preformatted { get; set; }
            public DateTime creationTimestamp { get; set; }
            public string creationSessionID { get; set; }
            public DateTime lastChangeTimestamp { get; set; }
            public string lastChangeSessionID { get; set; }
        }

        [Serializable]
        public class Medium
        {
            public string content { get; set; }
            public string creationSessionID { get; set; }
            public DateTime creationTimestamp { get; set; }
            public DateTime lastChangeTimestamp { get; set; }
            public string lastChangeSessionID { get; set; }
            public string mediumID { get; set; }
            public string mimeType { get; set; }
            public Properties properties { get; set; }
            public string title { get; set; }
            public string url { get; set; }
            public string urlEncoded { get; set; }

        }

        [Serializable]
        public class Memory
        {
            public string memoryID { get; set; }
            public string memoryType { get; set; } //Question or story
            public string lastRead { get; set; }
            public int readOccurrencies { get; set; }
            public string receiverID { get; set; }
            public string receiverTag { get; set; }
            public string receiverName { get; set; }
            public List<Medium> media { get; set; }
            public string text { get; set; }
            public List<string> textVariants { get; set; }
            public List<Answer> answers { get; set; }
            public string title { get; set; }
            public List<string> titleVariants { get; set; }
            public string date { get; set; }
            public double? dateUncertaintyDays { get; set; }
            public string placeName { get; set; }
            public double? placeLatitude { get; set; }
            public double? placeLongitude { get; set; }
            public double? placeUncertaintyKm { get; set; }
            public bool preformatted { get; set; }
            public bool conclusive { get; set; }
            public bool notPickable { get; set; }
            public bool help { get; set; }
            public Dictionary<string, string> contextVarsToSet { get; set; }
            public Dictionary<string, string> contextVarsToMatch { get; set; }
            public DateTime creationTimestamp { get; set; }
            public string creationSessionID { get; set; }
            public DateTime lastChangeTimestamp { get; set; }
            public string lastChangeSessionID { get; set; }
        }

        [Serializable]
        public class Properties
        {
            public bool executable;
        }


    }
}
