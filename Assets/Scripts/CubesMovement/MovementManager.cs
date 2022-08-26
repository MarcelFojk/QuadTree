using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    private CubesCreator _cubesCreator;

    [SerializeField]
    private CubesParameters _parameters;

    private InputSystem _inputActions;

    private List<GameObject> _cubesList;

    private readonly Dictionary<GameObject, object[]> _velocityDic = new Dictionary<GameObject, object[]>();

    public static Action _spacePressed;

    private float _cubeMinimumVelocity;
    private float _cubeMaximumVelocity;

    private void Awake()
    {
        _inputActions = new InputSystem();

        _cubeMinimumVelocity = _parameters.cubeMinimumVelocity;
        _cubeMaximumVelocity = _parameters.cubeMaximumVelocity;
    }

    private void Start()
    {
        _cubesList = _cubesCreator.listOfCubes;

        GetSpeed();
    }

    private void GetSpeed()
    {   
        for (int i = 0; i < _cubesList.Count; i++)
        {   
            //pairs the cube with random velocity magnitude and random direction
            _velocityDic.Add(_cubesList[i], new object[] { UnityEngine.Random.Range(_cubeMinimumVelocity, _cubeMaximumVelocity), 
                new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized });
        }
    }

    private void MoveCubes(InputAction.CallbackContext obj)
    {
        _spacePressed?.Invoke();

        for (int i = 0; i < _cubesList.Count; i++)
        {
            Vector3 velocity = (float)_velocityDic[_cubesList[i]][0] * (Vector3)_velocityDic[_cubesList[i]][1];

            _cubesList[i].GetComponent<Rigidbody>().velocity = velocity;
        }

        _inputActions.Action.MoveCubes.performed -= MoveCubes;
    }

    private void QuitApplication(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Action.MoveCubes.performed += MoveCubes;
        _inputActions.Action.Quit.performed += QuitApplication;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Action.MoveCubes.performed -= MoveCubes;
        _inputActions.Action.Quit.performed -= QuitApplication;
    }
}
