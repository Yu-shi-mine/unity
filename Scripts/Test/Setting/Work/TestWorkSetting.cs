using System.IO;
using System.Collections.Generic;
using UnityEngine;

using Setting.Work;
using Utility.IO;
using Utility.Serialize;

namespace Test
{
    public class TestWorkSetting
    {
        // Member
        private static string _fileName = "data.json";
        private static string _directory = "E:\\WORKSPACE\\UnityProjects\\MyTest\\AppData\\Setting\\Work";
        private static string _meshPath = "E:\\WORKSPACE\\UnityProjects\\MyTest\\AppData\\Mesh\\Work\\Wolf.stl";
        private static SerializableDictionary<Vector3, int> _Pose = new SerializableDictionary<Vector3, int>()
    {
        { Vector3.up, 0 },
        { Vector3.down, 1 },
        { Vector3.left, 2 },
        { Vector3.right, 3 },
        { Vector3.forward, 4 },
        { Vector3.back, 5 },
    };

        // Public Method
        public static void Save()
        {
            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }
            string path = Path.Combine(_directory, _fileName);
            WorkSetting setting = new WorkSetting(path, _Pose, _meshPath);
            string json = JsonUtility.ToJson(setting, true);
            JsonIO.Save(json, path);
        }

        public static void Load()
        {
            string path = Path.Combine(_directory, _fileName);
            string json = JsonIO.Load(path);
            WorkSetting setting = JsonUtility.FromJson<WorkSetting>(json);
        }
    }
}

