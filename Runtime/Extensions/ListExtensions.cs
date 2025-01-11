using System.Collections.Generic;
using UnityEngine;

namespace ID.Extensions
{
    public static class ListExtensions
    {
        public static List<T> DeleteObjsAndClear<T>(this List<T> list) where T : Component
        {
            foreach (var val in list)
            {
                if (val == null) continue;
                MonoBehaviour.Destroy(val.gameObject);
            }
            list.Clear();
            return list;
        }
    }
}
