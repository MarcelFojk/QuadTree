using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CubesParameters : ScriptableObject
{
    public enum Figure
    {
        Circle,
        Ellipse
    }

    public Figure figure;

    public int numberOfCubes;

    public float circleRadius;

    public float ellipseMajorAxis;

    public float ellipseMinorAxis;

    public float cubeMinimumVelocity;

    public float cubeMaximumVelocity;

    public float cubeCollisionRadius;
}
