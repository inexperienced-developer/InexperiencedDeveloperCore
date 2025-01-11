using UnityEngine;  

namespace ID.Utils
{
    public static class StrippedDebug
    {
        public static void Log(string msg)
        {
#if UNITY_EDITOR
            Debug.Log(msg);
#endif
        }

        public static void LogWarning(string msg)
        {
#if UNITY_EDITOR
            Debug.LogWarning(msg);
#endif
        }

        public static void LogError(string msg)
        {
#if UNITY_EDITOR
            Debug.LogError(msg);
#endif
        }

        public static void Assert(Object obj)
        {
#if UNITY_EDITOR
            Debug.Assert(obj != null);
#endif
        }
    }
}
