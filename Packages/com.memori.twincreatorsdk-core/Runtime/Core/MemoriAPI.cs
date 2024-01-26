using System;
using System.Collections.Generic;

namespace TwinCreator.Core
{
    public class MemoriAPI
    {
        [Serializable]
        public class PostMemoriID
        {
            public string tenantName { get; set; }
            public string strUserID { get; set; }
            public string strMemoriID { get; set; }
            public string strToken { get; set; }
        }

        [Serializable]
        public class PostMemoriName
        {
            public string tenantName { get; set; }
            public string userName { get; set; }
            public string memoriName { get; set; }
        }

        [Serializable]
        public class Integration
        {
            public string integrationID { get; set; }
            public string memoriID { get; set; }
            public string type { get; set; }
            public string state { get; set; }
            public List<string> deviceEmails { get; set; }
            public string invocationText { get; set; }
            public string jobID { get; set; }
            public string customData { get; set; }
            public List<Resource> resources { get; set; }
            public bool publish { get; set; }
            public DateTime creationTimestamp { get; set; }
            public DateTime lastChangeTimestamp { get; set; }
        }

        [Serializable]
        public class Memori
        {
            public string memoriID { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public List<string> recoveryTokens { get; set; }
            public string newPassword { get; set; }
            public string ownerUserID { get; set; }
            public string ownerUserName { get; set; }
            public string ownerTenantName { get; set; }
            public string memoriConfigurationID { get; set; }
            public string description { get; set; }
            public string engineMemoriID { get; set; }
            public bool isowner { get; set; }
            public bool isgiver { get; set; }
            public bool isreceiver { get; set; }
            public string giverTag { get; set; }
            public string giverPIN { get; set; }
            public string privacyType { get; set; }
            public string secretToken { get; set; }
            public string minimumNumberOfRecoveryTokens { get; set; }
            public string totalNumberOfRecoveryTokens { get; set; }
            public List<SentInvitation> sentInvitations { get; set; }
            public List<ReceivedInvitation> receivedInvitations { get; set; }
            public List<Integration> integrations { get; set; }
            public string avatarURL { get; set; }
            public string coverURL { get; set; }
            public string avatar3DURL { get; set; }
            public bool needsPosition { get; set; }
            public string voiceType { get; set; }
            public string culture { get; set; }
            public List<string> categories { get; set; }
            public bool exposed { get; set; }
            public bool disableR2R3Loop { get; set; }
            public bool disableR4Loop { get; set; }
            public string contentQualityIndex { get; set; }
            public string contentQualityIndexTimestamp { get; set; }
            public bool publishedInTheMetaverse { get; set; }
            public string metaverseEnvironment { get; set; }
            public List<string> properties { get; set; }
            public string blockedUntil { get; set; }
            public string creationTimestamp { get; set; }
            public string lastChangeTimestamp { get; set; }
        }

        [Serializable]
        public class ReceivedInvitation
        {
            public string invitationID { get; set; }
            public string memoriID { get; set; }
            public bool isInviter { get; set; }
            public bool isInvitee { get; set; }
            public string text { get; set; }
            public string destinationName { get; set; }
            public string destinationEMail { get; set; }
            public string tag { get; set; }
            public string pin { get; set; }
            public string type { get; set; }
            public string state { get; set; }
            public DateTime creationTimestamp { get; set; }
            public DateTime lastChangeTimestamp { get; set; }
        }

        [Serializable]
        public class Resource
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        [Serializable]
        public class RootMetaverse
        {
            public List<Memori> memori { get; set; }
            public int requestID { get; set; }
            public DateTime requestDateTime { get; set; }
            public int resultCode { get; set; }
            public string resultMessage { get; set; }
        }

        [Serializable]
        public class Root
        {
            public Memori memori { get; set; }
            public int requestID { get; set; }
            public DateTime requestDateTime { get; set; }
            public int resultCode { get; set; }
            public string resultMessage { get; set; }
        }

        [Serializable]
        public class RootSelection
        {
            public string button { get; set; }
            public string memoriId { get; set; }
            public string avatarFullBodyURL { get; set; }
            public string tenant { get; set; }
            public Memori twin { get; set; }
        }

        [Serializable]
        public class SentInvitation
        {
            public string invitationID { get; set; }
            public string memoriID { get; set; }
            public bool isInviter { get; set; }
            public bool isInvitee { get; set; }
            public string text { get; set; }
            public string destinationName { get; set; }
            public string destinationEMail { get; set; }
            public string tag { get; set; }
            public string pin { get; set; }
            public string type { get; set; }
            public string state { get; set; }
            public string creationTimestamp { get; set; }
            public string lastChangeTimestamp { get; set; }
        }

    }


}

