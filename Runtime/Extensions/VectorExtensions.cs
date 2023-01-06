using UnityEngine;

namespace InexperiencedDeveloper.Extensions
{
    public static class VectorExtensions
    {
        //Quick SquareDistance
        public static float SqrDistance(this Vector3 a, Vector3 b)
        {
            return (a - b).sqrMagnitude;
        }
    }
}