using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{
    public static Vector2 RadianToVector2(this float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
    
    public static Vector2 RadianToVector2(this float radian, float length)
    {
        return RadianToVector2(radian) * length;
    }

    public static Vector2 DegreeToVector2(this float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }

    public static Vector2 DegreeToVector2(this float degree, float length)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad) * length;
    }

    public static float LinearRemap(this float value, float valueRangeMin, float valueRangeMax, float newRangeMin, float newRangeMax)
    {
        return (value - valueRangeMin) / (valueRangeMax - valueRangeMin) * (newRangeMax - newRangeMin) + newRangeMin;
    }
}
