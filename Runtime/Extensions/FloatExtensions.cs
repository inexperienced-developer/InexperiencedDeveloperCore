namespace ID.Extensions
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Normalizes an angle to between -180 and 180
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float NormalizeAngleTo180(this float angle)
        {
            while (angle > 180)
                angle -= 360;
            while (angle < -180)
                angle += 360;

            return angle;
        }

        /// <summary>
        /// Normalizes an angle to between 0 and 360
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float NormalizeAngleTo360(this float angle)
        {
            while (angle > 360)
                angle -= 360;
            while (angle < 0)
                angle += 360;

            return angle;
        }

        public static float Normalize01(this float a, float min, float max)
        {
            return (a - min) / (max - min);
        }
    }

}