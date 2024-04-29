using System.Collections.Generic;
using UnityEngine;

using Utility.Serialize;

namespace Setting.Work
{
    [System.Serializable]
    public class WorkSetting : SettingBase
    {
        // Inheritance
        public override string Type
        {
            get { return TYPE; }
        }


        // Constant
        public const string TYPE = "Work";


        // Property
        public SerializableDictionary<Vector3, int> Pose;
        public string MeshPath;


        // Constructor
        public WorkSetting(string path, SerializableDictionary<Vector3, int> pose, string meshPath) : base(path)
        {
            Pose = pose;
            MeshPath = meshPath;
        }
    }
}

