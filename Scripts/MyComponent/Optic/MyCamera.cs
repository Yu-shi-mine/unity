using System;
using UnityEngine;
using UnityEngine.Assertions;

using Setting;
using Setting.Optic;

namespace MyComponent.Optic
{
    [RequireComponent(typeof(Camera))]
    public class MyCamera : MonoBehaviour, IMyComponent
    {
        // Property


        // Member
        private Camera _camera;
        private int _cmosWidth;
        private int _cmosHeight;


        // Inheritance
        public void LoadSetting<T>(T setting) where T : SettingBase
        {
            try
            {
                Initialize();
                Assert.AreEqual(setting.Type, CameraSetting.TYPE);
                _LoadSetting(setting as CameraSetting);
            }
            catch (Exception ex)
            {
                Message.Send(ex.Message);
            }
        }


        // Public Method
        public void Initialize() => _camera = GetComponent<Camera>();


        // Private Method
        private void _LoadSetting(CameraSetting setting)
        {
            _cmosWidth = setting.CMOS.Width;
            _cmosHeight = setting.CMOS.Height;
            _camera.sensorSize = new Vector2(_cmosWidth * setting.CMOS.PixWidth / 1000, _cmosHeight * setting.CMOS.PixHeight / 1000);
            _camera.focalLength = setting.Lens.FocalLenght;
            transform.position = new Vector3(0f, setting.WorkDistance / 1000f, 0f);
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}

