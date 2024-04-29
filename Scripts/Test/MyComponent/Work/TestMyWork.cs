using System.IO;
using UnityEngine;

using Setting.Work;
using MyComponent.Work;
using Utility.IO;

namespace Test
{
    public class TestMyWork : MonoBehaviour
    {
        // Member
        private static string _fileName = "data.json";
        private static string _directory = "E:\\WORKSPACE\\UnityProjects\\MyTest\\AppData\\Setting\\Work";
        private static string _objName = "Wolf";

        // Public Method
        public static void Load()
        {
            MyWork work = GameObject.Find(_objName).GetComponent<MyWork>();

            string path = Path.Combine(_directory, _fileName);
            string json = JsonIO.Load(path);
            WorkSetting setting = JsonUtility.FromJson<WorkSetting>(json);
            work.LoadSetting(setting);
        }
    }
}

