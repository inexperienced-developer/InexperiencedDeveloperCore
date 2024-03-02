using UnityEngine;

namespace InexperiencedDeveloper.Utils
{
    public static class MathUtils
    {
        /// <summary>
        /// Represents the mathematical constant PI.
        /// </summary>
        public const float PI = 3.141593f;

        /// <summary>
        /// Defines the conversion factor from degrees to radians, used to convert angles from degrees to radians.
        /// </summary>
        public const float DEG2RAD = 57.29578f;

        /// <summary>
        /// Remaps a value from one range to another. This is useful for scaling a value that lies within a given range to a new range,
        /// maintaining the proportion within the new range.
        /// </summary>
        /// <param name="val">The value to remap.</param>
        /// <param name="min">The minimum value of the original range.</param>
        /// <param name="max">The maximum value of the original range.</param>
        /// <param name="newMin">The minimum value of the new range.</param>
        /// <param name="newMax">The maximum value of the new range.</param>
        /// <returns>The remapped value within the new range.</returns>
        public static float Remap(float val, float min, float max, float newMin, float newMax)
        {
            return newMin + (val - min) * (newMax - newMin) / (max - min);
        }

        /// <summary>
        /// A convenience method for remapping a value to the normalized range of 0 to 1.
        /// This is useful for normalizing a value that lies within a specific range to a value between 0 and 1.
        /// </summary>
        /// <param name="val">The value to remap.</param>
        /// <param name="min">The minimum value of the original range.</param>
        /// <param name="max">The maximum value of the original range.</param>
        /// <returns>The remapped value within the range of 0 to 1.</returns>
        public static float Remap01(float val, float min, float max) => Remap(val, min, max, 0, 1);

        /// <summary>
        /// Calculates the remainder of a division without using the modulo operator, by subtracting the product of the divisor's floor value
        /// and the divisor from the dividend. This method is useful for wrapping values within a certain range, such as angles or indices.
        /// </summary>
        /// <param name="val">The dividend value.</param>
        /// <param name="wrap">The divisor value for wrapping.</param>
        /// <returns>The wrapped value within the range from 0 to wrap.</returns>
        public static float NonModuloWrap(float val, float wrap) => val - Mathf.Floor(val / wrap) * wrap;

        /// <summary>
        /// Determines the Greatest Common Divisor (GCD) of two integers using the Euclidean algorithm. The GCD is the largest integer
        /// that divides both numbers without leaving a remainder. This method is essential for simplifying fractions and calculating
        /// the Least Common Multiple (LCM).
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The greatest common divisor of a and b.</returns>
        public static int GetGreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Calculates the Least Common Multiple (LCM) of two numbers based on their Greatest Common Divisor (GCD).
        /// The LCM is the smallest number that is a multiple of both a and b. This method is useful in problems that involve
        /// finding common multiples, such as synchronizing cycles or combining fractions with different denominators.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The least common multiple of a and b.</returns>
        public static int GetLeastCommonMultiple(int a, int b) => (a / GetGreatestCommonDivisor(a, b)) * b;
    }
}
