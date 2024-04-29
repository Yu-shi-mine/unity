using System;
using UnityEngine;

namespace Test
{
    public class TestMain : MonoBehaviour
    {
        // Public Method
        #region Test MyComponent

        #region Work
        [ContextMenu("MyWork")]
        public void TEST_MY_WORK()
        {
#if UNITY_EDITOR
            TEST("ワーク設定の読込&反映", TestMyWork.Load);
#endif
        }
        #endregion

        #region Camera
        [ContextMenu("MyCamera")]
        public void TEST_MY_CAMERA()
        {
#if UNITY_EDITOR
            TEST("カメラ設定の読込&反映", TestMyCamera.Load);
#endif
        }
        #endregion

        #endregion


        #region Test Setting IO

        #region Work
        [ContextMenu("Work Setting IO")]
        public void TEST_WORK_SETTING_IO()
        {
#if UNITY_EDITOR
            TEST("ワーク設定の保存", TestWorkSetting.Save);
            TEST("ワーク設定の読込", TestWorkSetting.Load);
#endif
        }
        #endregion

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


        #region Test Utility

        #region Test Mesh IO
        [ContextMenu("Test Mesh IO")]
        public void TEST_MESH_IO()
        {
#if UNITY_EDITOR
            TEST("メッシュの保存", TestMeshIO.Save);
            TEST("メッシュの読込", TestMeshIO.Load);
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
                Message.Send(testMessage + ": NG -> " + ex.Message + ex.StackTrace);
            }
        }
    }
}

