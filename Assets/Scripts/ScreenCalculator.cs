using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCalculator
{
    static float left;
    static float right;
    static float top;
    static float bottom;

    /// <summary>
    /// Gives left edges coordinates
    /// </summary>
    public static float Left
    {
        get
        {
            return left;
        }
    }

    /// <summary>
    /// Gives right edges coordinates
    /// </summary>
    public static float Right
    {
        get
        {
            return right;
        }
    }

    /// <summary>
    /// Gives top edges coordinates
    /// </summary>
    public static float Top
    {
        get
        {
            return top;
        }
    }

    /// <summary>
    /// Gives bottom edges coordinates
    /// </summary>
    public static float Bottom
    {
        get
        {
            return bottom;
        }
    }

    public static void Init()
    {
        float screenZaxis = -Camera.main.transform.position.z;
        Vector3 leftBottomCorner = new Vector3(0, 0, screenZaxis);
        Vector3 rightBottomCorner = new Vector3(Screen.width, Screen.height, screenZaxis);

        Vector3 leftBottomCornerGameWorld = Camera.main.ScreenToWorldPoint(leftBottomCorner);
        Vector3 rightBottomCornerGameWorld = Camera.main.ScreenToWorldPoint(rightBottomCorner);

        left = leftBottomCornerGameWorld.x;
        right = rightBottomCornerGameWorld.x;
        top = rightBottomCornerGameWorld.y;
        bottom = leftBottomCornerGameWorld.y;

    }
}
