using UnityEngine;

public class Message : MonoBehaviour
{
    // Public Method
    public static void Send(string text)
    {
#if UNITY_EDITOR
        Debug.Log(text);
#else

#endif
    }
}
