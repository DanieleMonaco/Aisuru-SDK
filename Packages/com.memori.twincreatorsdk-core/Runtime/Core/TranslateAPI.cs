using System;
using System.Collections.Generic;

namespace TwinCreator.Core
{
    
    public class TranslateAPI
    {
        [Serializable]
        public class TranslateInformation
        {
            public string text;
            public string target_lang;
            public string source_lang;
        }

        [Serializable]
        public class Root
        {
            public List<Translation> translations { get; set; }
        }

        [Serializable]
        public class Translation
        {
            public string detected_source_language { get; set; }
            public string text { get; set; }
        }

    }


}