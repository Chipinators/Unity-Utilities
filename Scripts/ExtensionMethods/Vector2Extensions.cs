using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 WithX(this Vector2 v, float x)
    {
        return new Vector2(x, v.y);
    }

    public static Vector2 WithY(this Vector2 v, float y)
    {
        return new Vector2(v.x, y);
    }

    public static Vector3 WithZ(this Vector2 v, float z)
    {
        return new Vector3(v.x, v.y, z);
    }

    public static float AngleTo(this Vector2 v, Vector2 to)
    {
        Vector2 direction = to - v;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0f) angle += 360f;
        return angle;
    }
}
