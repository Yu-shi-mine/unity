using System;
using UnityEngine;

namespace Test
{
    public class TestMain : MonoBehaviour
    {
        // Public Method
        #region Test MyComponent

        #region Camera
        [ContextMenu("Camera Component")]
        public void TEST_CAM_COMPONENT()
        {
#if UNITY_EDITOR
            TEST("カメラ設定の読込&反映", TestMyCamera.Load);
#endif
        }
        #endregion

        #endregion


        #region Test Setting IO

        #region Camera
        [ContextMenu("Camera Setting IO")]
        public void TEST_CAM_SETTING_IO()
        {
#if UNITY_EDITOR
            TEST("カメラ設定の保存", TestCameraSetting.Save);
            TEST("カメラ設定の読込", TestCameraSetting.Load);
#endif
        }
        #endregion

        #endregion


        // Private Method
        private void TEST(string testMessage, Action func)
        {
            try
            {
                func();
                Message.Send(testMessage + ": OK");
            }
            catch (Exception ex)
            {
                Message.Send(testMessage + ": NG -> " + ex.Message);
            }
        }
    }
}

