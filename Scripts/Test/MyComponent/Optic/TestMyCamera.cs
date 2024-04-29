using System.IO;
using System;
using UnityEngine;

using MyComponent.Optic;
using Setting.Optic;
using Utility.IO;

namespace Test
{
    public class TestMyCamera : MonoBehaviour
    {
        // Member
        private static string _fileName = "data.json";
        private static string _camDirectory = "E:\\WORKSPACE\\UnityProjects\\MyTest\\AppData\\Setting\\Optic\\Camera";
        private static string _camName = "CaptureCamera";


        // Public Method
        public static void Load()
        {
            MyCamera camera = GameObject.Find(_camName).GetComponent<MyCamera>();

            string camPath = Path.Combine(_camDirectory, _fileName);
            string camJson = JsonIO.Load(camPath);
            CameraSetting cam = JsonUtility.FromJson<CameraSetting>(camJson);
            camera.LoadSetting(cam);
        }
    }
}

