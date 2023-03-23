public static class MathUtils
{
    public static float Remap(float val, float min, float max, float newMin, float newMax)
    {
        return newMin + (val - min) * (newMax - newMin) / (max - min);
    }

    public static float Remap01(float val, float min, float max)
    {
        return Remap(val, min, max, 0, 1);
    }
}
