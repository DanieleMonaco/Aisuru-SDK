using UnityEngine;

namespace TwinCreator.Core
{
    [CreateAssetMenu(fileName = "ServerData", menuName = "Memori/ServerData", order = 0)]
    public class ServerData : ScriptableObject
    {
        [Header("Personal informations")] public string userName;
        public string ownerID;
        public string tenantName;
        public string passwordMemori;
        public string MemoriNameURL = "https://backend.memori.ai/api/v2/Memori/";

        public string
            MemoriIDURL = "https://backend.memori.ai/api/v2/MemoriByID"; // tenant/user/memori/{strToken}?strToken=token

        public string SessionURL = "https://engine.memori.ai/memori/v2/Session/";
        public string DialogueURL = "https://engine.memori.ai/memori/v2/TextEnteredEvent/";
        public string TranslateURL = "https://app.memorytwin.com/api/translate";
        public string MediaURL = "https://app.memorytwin.com/api/media"; //?mimeType &url
        public string MemoriesURL = "https://engine.memoriDialog.ai/memoriDialog/v2/Memories/";
        public string MetaverseGetSpaceURL = "https://metaverse.memori.ai/api/v1/spaces/";

        public string MetaverseURLCreator =
            "https://backend.memori.ai/api/v2/TenantMetaverseMemori/app.twincreator.com";

        public string MetaverseURLTwin = "https://backend.memori.ai/api/v2/TenantMetaverseMemori/app.memorytwin.com";
        public int sizeInventory = 10;

        [Header("Azure key")] public string KeyAzure = "7675e0eb17194c78b9d616a18fc2e48f";
        public string RegionAzure = "westeurope";

    }

}