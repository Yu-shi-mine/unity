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
            TEST("���[�N�ݒ�̓Ǎ�&���f", TestMyWork.Load);
#endif
        }
        #endregion

        #region Camera
        [ContextMenu("MyCamera")]
        public void TEST_MY_CAMERA()
        {
#if UNITY_EDITOR
            TEST("�J�����ݒ�̓Ǎ�&���f", TestMyCamera.Load);
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
            TEST("���[�N�ݒ�̕ۑ�", TestWorkSetting.Save);
            TEST("���[�N�ݒ�̓Ǎ�", TestWorkSetting.Load);
#endif
        }
        #endregion

        #region Camera
        [ContextMenu("Camera Setting IO")]
        public void TEST_CAM_SETTING_IO()
        {
#if UNITY_EDITOR
            TEST("�J�����ݒ�̕ۑ�", TestCameraSetting.Save);
            TEST("�J�����ݒ�̓Ǎ�", TestCameraSetting.Load);
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
            TEST("���b�V���̕ۑ�", TestMeshIO.Save);
            TEST("���b�V���̓Ǎ�", TestMeshIO.Load);
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

