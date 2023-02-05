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

        //Outputs a random Vector3 within the given range
        public static Vector3 RandomVector3(this Vector3 v, float min, float max)
        {
            return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
        }

        //Flattens the vector on the Y-Axis
        public static Vector3 Flatten(this Vector3 v)
        {
            v.y = 0;
            return v;
        }
    }
}