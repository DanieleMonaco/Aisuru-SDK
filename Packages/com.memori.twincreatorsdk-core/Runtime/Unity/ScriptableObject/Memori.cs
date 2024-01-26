using System;
using TwinCreator.Core;
using UnityEngine;

namespace TwinCreator.Core
{
    public class InstancedMemori
    {
        public string token = null;
        public string IDEngineMemori;
        public string IDMemori;
        public string PasswordMemori;
        public string MemoriName;
        public string glbURL;
        public MemoriAPI.Root MemoriRoot { get; set; }

        public void FromScriptableObject(Memori memori)
        {
            token = memori.token;
            IDEngineMemori = memori.IDEngineMemori;
            IDMemori = memori.IDMemori;
            PasswordMemori = memori.PasswordMemori;
            MemoriName = memori.MemoriName;
            glbURL = memori.glbURL;
            MemoriRoot = memori.MemoriRoot;
        }
    }
    
    
    /// <summary>
    /// contiene tutte le informazioni di un memori.
    /// Le informazioni di un memori si recuperano sulle impostazioni del memori su memori.ai
    /// </summary>
    [CreateAssetMenu(fileName = "Memori", menuName = "Memori/Create Memori", order = 3)]
    public class Memori : ScriptableObject
    {
        public string token = null; //not required: insert null if you dont use it
        public string IDEngineMemori;
        public string IDMemori;
        public string PasswordMemori;
        public string MemoriName;
        public string glbURL;
        public MemoriAPI.Root MemoriRoot { get; set; }

    }
}