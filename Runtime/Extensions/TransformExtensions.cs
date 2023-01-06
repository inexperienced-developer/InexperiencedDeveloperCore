using UnityEngine;

namespace InexperiencedDeveloper.Extensions
{
    public static class TransformExtensions
    {
        //Quick SquareDistance
        public static float SqrDistance(this Transform a, Vector3 b)
        {
            return (a.position - b).sqrMagnitude;
        }

        //An adjusted position to fire raycasts from
        public static Vector3 ElevatedPostion(this Transform a, float offset = 1) => new Vector3(a.position.x, a.position.y + offset, a.position.z);

        //Traverses a transform to find a specific child
        public static Transform FindChildRecursive(this Transform t, string childName)
        {
            foreach (Transform child in t)
            {
                if (child.name == childName)
                    return child;
                else
                {
                    Transform found = child.FindChildRecursive(childName);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }


        //Runtime change all children layers
        public static void ChangeChildLayersRecursive(this Transform t, int layer)
        {
            foreach (Transform child in t)
            {
                child.gameObject.layer = layer;
                ChangeChildLayersRecursive(child, layer);
            }
        }
    }
}

