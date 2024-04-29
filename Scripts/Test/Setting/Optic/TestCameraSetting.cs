using System;
using System.IO;
using UnityEngine;

using Setting.Optic;
using Utility.IO;

namespace Test
{
    public class TestCameraSetting
    {
        // Member
        private static string _fileName = "data.json";

        private static string _camDrectory = "E:\\WORKSPACE\\UnityProjects\\MyTest\\AppData\\Setting\\Optic\\Camera";
        private static float _workDistance = 650f;
        
        private static string _cmosDirectory = "E:\\WORKSPACE\\UnityProjects\\MyTest\\AppData\\Setting\\Optic\\CMOS";
        private static int _cmosWidth = 1920;
        private static int _cmosHeight = 1080;
        private static float _pixWidth = 3.45f;
        private static float _pixHeight = 3.45f;

        private static string _lensDirectory = "E:\\WORKSPACE\\UnityProjects\\MyTest\\AppData\\Setting\\Optic\\Lens";
        private static float _focalLength = 20;


        // Public Method
        public static void Save()
        {
            // CMOSê›íË
            if (!Directory.Exists(_cmosDirectory))
            {
                Directory.CreateDirectory(_cmosDirectory);
            }
            string cmosPath = Path.Combine(_cmosDirectory, _fileName);
            CMOSSetting cmosSetting = new CMOSSetting(cmosPath, _cmosWidth, _cmosHeight, _pixWidth, _pixHeight);
            string cmosJson = JsonUtility.ToJson(cmosSetting, true);
            JsonIO.Save(cmosJson, cmosPath);


            // Lensê›íË
            if (!Directory.Exists(_lensDirectory))
            {
                Directory.CreateDirectory(_lensDirectory);
            }
            string lensPath = Path.Combine(_lensDirectory, _fileName);
            LensSetting lensSetting = new LensSetting(lensPath, _focalLength);
            string lensJson = JsonUtility.ToJson(lensSetting, true);
            JsonIO.Save(lensJson, lensPath);

            //Cameraê›íË
            string camPath = Path.Combine(_camDrectory, _fileName);
            CameraSetting camSetting = new CameraSetting(camPath, cmosSetting, lensSetting, _workDistance);
            string camJson = JsonUtility.ToJson(camSetting, true);
            JsonIO.Save(camJson, camPath);
        }

        public static void Load()
        {
            // CMOSê›íË
            string cmosPath = Path.Combine(_cmosDirectory, _fileName);
            string cmosJson;
            using (StreamReader sr = new StreamReader(cmosPath))
            {
                cmosJson = sr.ReadToEnd();
            }
            CMOSSetting cmos = JsonUtility.FromJson<CMOSSetting>(cmosJson);

            // Lensê›íË
            string lensPath = Path.Combine(_lensDirectory, _fileName);
            string lensJson;
            using (StreamReader sr = new StreamReader(lensPath))
            {
                lensJson = sr.ReadToEnd();
            }
            LensSetting lens = JsonUtility.FromJson<LensSetting>(lensJson);

            // ÉJÉÅÉâê›íË
            string camPath = Path.Combine(_camDrectory, _fileName);
            string camJson;
            using (StreamReader sr = new StreamReader(camPath))
            {
                camJson = sr.ReadToEnd();
            }
            CameraSetting cam = JsonUtility.FromJson<CameraSetting>(camJson);
        }
    }
}

