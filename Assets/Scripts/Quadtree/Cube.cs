using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point
{
    public float X;
    public float Y;
    public GameObject UserData;

    public Point(float x, float y, GameObject userData)
    {
        X = x;
        Y = y;
        UserData = userData;
    }
}
