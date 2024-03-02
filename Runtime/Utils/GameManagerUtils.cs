using System;
using System.Collections.Generic;
using UnityEngine;

namespace InexperiencedDeveloper.Utils
{
    public static class GameManagerUtils
    {
        /// <summary>
        /// Creates a new GameObject, names it, sets it as a child of a specified Transform, and adds a component of type T to it.
        /// </summary>
        /// <typeparam name="T">The type of MonoBehaviour to add to the newly created GameObject.</typeparam>
        /// <param name="transform">The parent Transform to which the new GameObject will be attached.</param>
        /// <param name="name">The name to assign to the new GameObject.</param>
        /// <returns>The component of type T added to the GameObject.</returns>
        public static T AddManager<T>(Transform transform, string name) where T : MonoBehaviour
        {
            GameObject go = new GameObject(name);
            go.transform.SetParent(transform, false);
            return go.AddComponent<T>();
        }

        /// <summary>
        /// Activates a specified number of objects in an array of MonoBehaviour objects. If the array has fewer elements than required,
        /// it is resized. Returns the index of the last object activated or the index where new objects should be added.
        /// </summary>
        /// <typeparam name="T">The type of MonoBehaviour the objects array consists of.</typeparam>
        /// <param name="objects">A reference to the array of MonoBehaviour objects to be activated.</param>
        /// <param name="totalToActivate">The total number of objects to activate.</param>
        /// <returns>The index of the last object that was activated or where new objects should be added.</returns>
        public static int ActivateObjectsInPool<T>(ref T[] objects, int totalToActivate) where T : MonoBehaviour
        {
            int lastIndex = 0;
            if (objects != null)
            {
                // Activates the required number of objects if they exist.
                for (int i = 0; i < objects.Length && i < totalToActivate; i++)
                {
                    objects[i].gameObject.SetActive(true);
                    lastIndex++;
                }
                // Resizes the array if there are not enough objects to meet the requirement.
                if (objects.Length < totalToActivate) Array.Resize(ref objects, totalToActivate);
            }
            else
            {
                // Initializes the array if it is null.
                objects = new T[totalToActivate];
            }
            return lastIndex;
        }
    }
}
