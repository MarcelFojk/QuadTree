using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField]
    private CubesParameters _parameters;

    [SerializeField]
    private GameObject _prefab;

    private int _numberOfCubes;
    private float _circleRadius;

    [HideInInspector]
    public List<GameObject> listOfCubes;

    private void Awake()
    {
        _numberOfCubes = _parameters.numberOfCubes;
        _circleRadius = _parameters.circleRadius;

        CreateCubes();
    }

    private void CreateCubes()
    {
        for (int i = 0; i < _numberOfCubes; i++)
        {
            if (_parameters.figure == CubesParameters.Figure.Ellipse)
            {
                Vector3 position = CalculatePositionOnEllipse(i);
                InstantiateCube(position);
            }
            else if(_parameters.figure == CubesParameters.Figure.Circle)
            {
                Vector3 position = CalculatePositionOnCircle(i);
                InstantiateCube(position);
            }
        }
    }

    private void InstantiateCube(Vector3 position)
    {   
        Quaternion rotation = CalculateRotation(position);

        GameObject cube = Instantiate(_prefab, position, rotation);

        listOfCubes.Add(cube);
    }

    private Vector3 CalculatePositionOnCircle(int counter)
    {
        float initialAngle = 90f;

        float angleChange = 360f / _numberOfCubes;

        float angleValue = Mathf.Deg2Rad * (initialAngle + angleChange * counter);

        float x = Mathf.Cos(angleValue) * _circleRadius;
        float y = Mathf.Sin(angleValue) * _circleRadius;

        return new Vector3(x, y, 0);
    }

    private Vector3 CalculatePositionOnEllipse(int counter)
    {
        float initialAngle = 90.01f;

        float angleChange = 360f / _numberOfCubes;

        float angleValue = Mathf.Deg2Rad * (initialAngle + angleChange * counter);

        float degAngleValue = initialAngle + angleChange * counter;

        float x = 0f;
        float y = 0f;

        float a = _parameters.ellipseMajorAxis;
        float b = _parameters.ellipseMinorAxis;

        if (degAngleValue > 360f)
        {
            degAngleValue -= 360f;
        }

        // conditions for tangent function

        if ((degAngleValue >= 0f && degAngleValue < 90f) || (degAngleValue > 270f && degAngleValue <= 360f))
        {
            x = (a * b) / (Mathf.Sqrt(b * b + a * a * Mathf.Tan(angleValue) * Mathf.Tan(angleValue)));
            y = ((a * b) * Mathf.Tan(angleValue)) / (Mathf.Sqrt(b * b + a * a * Mathf.Tan(angleValue) * Mathf.Tan(angleValue)));
        }
        else if(degAngleValue > 90f && degAngleValue < 270f)
        {
            x = -(a * b) / Mathf.Sqrt(b * b + a * a * Mathf.Tan(angleValue) * Mathf.Tan(angleValue));
            y = (-(a * b) * Mathf.Tan(angleValue)) / (Mathf.Sqrt(b * b + a * a * Mathf.Tan(angleValue) * Mathf.Tan(angleValue)));
        }

        return new Vector3(x, y, 0);
    }

    private Quaternion CalculateRotation(Vector3 direction)
    {
        return Quaternion.FromToRotation(Vector3.up, direction);
    }

}
