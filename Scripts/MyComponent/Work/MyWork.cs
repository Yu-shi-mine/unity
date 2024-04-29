using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Setting;
using Setting.Work;
using Utility.IO;
using Utility.Serialize;

namespace MyComponent.Work
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class MyWork : MonoBehaviour
    {
        // Property
        public SerializableDictionary<Vector3, int> Pose;


        // Member


        //Inheritance
        public void Initialize()
        {

        }

        public void LoadSetting<T>(T setting) where T : SettingBase
        {
            try
            {
                Initialize();
                Assert.AreEqual(setting.Type, WorkSetting.TYPE);
                _LoadSetting(setting as WorkSetting);
            }
            catch (Exception ex)
            {
                Message.Send(ex.Message);
            }
        }


        // Private Method
        private void _LoadSetting(WorkSetting setting)
        {
            GetComponent<MeshFilter>().sharedMesh = MeshIO.Load(setting.MeshPath);
            Pose = setting.Pose;
        }
    }
}

