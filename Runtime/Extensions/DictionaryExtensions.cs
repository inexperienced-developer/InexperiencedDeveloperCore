using System.Collections.Generic;
using UnityEngine;

public static class DictionaryExtensions
{
    public static Dictionary<TKey, T> DeleteObjsAndClear<TKey, T>(this Dictionary<TKey, T> dict) where T : Component
    {
        foreach (var val in dict.Values)
        {
            if (val == null) continue;
            MonoBehaviour.Destroy(val.gameObject);
        }
        dict.Clear();
        return dict;
    }

    public static Dictionary<TKey, T> SafeAdd<TKey, T>(this Dictionary<TKey, T> dict, TKey key, T addValue) where T : Component
    {
        dict.TryGetValue(key, out T value);
        if (value == null)
        {
            dict.Add(key, addValue);
        }
        else
        {
            dict[key] = addValue;
        }
        return dict;
    }
}
