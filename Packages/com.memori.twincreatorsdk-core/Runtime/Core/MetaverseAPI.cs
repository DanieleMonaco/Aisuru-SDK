using System;
using System.Collections.Generic;
using UnityEngine;

namespace TwinCreator.Core
{
    public class MetaverseAPI
    {
        [Serializable]
        public class Tenant
        {
            public string name { get; set; }
            public string tenant_id { get; set; }
        }

        [Serializable]
        public class Asset
        {
            public string key { get; set; }
            public string url { get; set; }
            public string kind { get; set; }
            public string filename { get; set; }
            public string content_type { get; set; }
            public int size { get; set; }
            public string upload_id { get; set; }
        }

        [Serializable]
        public class Position
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
        }

        [Serializable]
        public class Rotation
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
        }

        [Serializable]
        public class Item
        {
            public string description { get; set; }
            public string name { get; set; }
            public string twin_uuid { get; set; }
            public string twin_initial_question { get; set; }
            public string twin_initial_context { get; set; }
            public string twin_owner_username { get; set; }
            public Asset asset { get; set; }
            public string id { get; set; }
            public Vector3 position { get; set; }
            public Vector3 rotation { get; set; }
            public Vector3 glb_offset_position { get; set; }
            public Vector3 glb_offset_rotation { get; set; }
            public Vector3 glb_offset_scale { get; set; }
        }

        [Serializable]
        public class Model
        {
            public string key { get; set; }
            public string memori_environment { get; set; }
            public string partition_key { get; set; }
            public string state { get; set; }
            public string state_details { get; set; }
            public int version { get; set; }
            public List<string> actions { get; set; }
            public List<Asset> assets { get; set; }
            public Vector3 entrypoint_position { get; set; }
            public Vector3 entrypoint_rotation { get; set; }
            public string parent { get; set; }
            public string id { get; set; }
            public List<Item> items { get; set; }
        }

        [Serializable]
        public class Space
        {
            public string created_at { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public bool published { get; set; }
            public string twin_initial_context { get; set; }
            public string twin_initial_question { get; set; }
            public string twin_owner_username { get; set; }
            public string twin_uuid { get; set; }
            public string updated_at { get; set; }
            public string id { get; set; }
            public string owner { get; set; }
            public Tenant tenant { get; set; }
            public List<Model> models { get; set; }
        }

    }
}