using System;

public static class MathExtensions
{
    public static float Remap(this float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        float fromAbs = from - fromMin;
        float fromMaxAbs = fromMax - fromMin;

        float normal = fromAbs / fromMaxAbs;

        float toMaxAbs = toMax - toMin;
        float toAbs = toMaxAbs * normal;

        float to = toAbs + toMin;

        return to;
    }

    public static int Remap(this int from, int fromMin, int fromMax, int toMin, int toMax)
    {
        int fromAbs = from - fromMin;
        int fromMaxAbs = fromMax - fromMin;

        int normal = fromAbs / fromMaxAbs;

        int toMaxAbs = toMax - toMin;
        int toAbs = toMaxAbs * normal;

        int to = toAbs + toMin;

        return to;
    }

    public static float LinearRemap(this float value, float valueRangeMin, float valueRangeMax, float newRangeMin,
        float newRangeMax)
    {
        return (value - valueRangeMin) / (valueRangeMax - valueRangeMin) * (newRangeMax - newRangeMin) +
               newRangeMin;
    }

    public static int WithRandomSign(this int value, float negativeProbability = 0.5f)
    {
        return UnityEngine.Random.value < negativeProbability ? -value : value;
    }

    public static float WithRandomSign(this float value, float negativeProbability = 0.5f)
    {
        return UnityEngine.Random.value < negativeProbability ? -value : value;
    }

    public static int RoundOff(this int i)
    {
        return (int)Math.Round(i / 10.0) * 10;
    }

    public static long RoundOff(this long i)
    {
        return (long)Math.Round(i / 10.0) * 10;
    }
    public static float Percentage(float value, float percentage)
    {
        return value * percentage / 100.00f;
    }
    public static float GetPercentage(this float value, float percentage)
    {
        return Percentage(value, percentage);
    }

}