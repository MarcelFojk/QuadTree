using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField]
    private CubesParameters _parameters;

    private void Start() // sets the camera position that the whole circle or ellipse is visible
    {
        if (_parameters.figure == CubesParameters.Figure.Circle)
        {
            transform.position = new Vector3(0, 0, -2.5f * _parameters.circleRadius);
        }
        else if (_parameters.figure == CubesParameters.Figure.Ellipse)
        {
            if (_parameters.ellipseMajorAxis >= _parameters.ellipseMinorAxis)
            {
                transform.position = new Vector3(0, 0, -1.5f * _parameters.ellipseMajorAxis);
            }
            else
            {
                transform.position = new Vector3(0, 0, -1.5f * _parameters.ellipseMinorAxis);
            }
        }
    }
}
