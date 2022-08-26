using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeCounterUI : MonoBehaviour
{
    [SerializeField]
    private CubesCreator _cubesCreator;

    private TextMeshProUGUI _text;

    private bool _isNextScene = false;

    private void OnEnable()
    {
        Initialization.sceneLoaded += NextScene;
    }

    private void Start()
    {
        _text = GameUIIsntance.Instance.textUI;
    }

    private void Update()
    {   
        if (_isNextScene)
        {
            ChangeText();
        }
    }

    private void ChangeText()
    {
        _text.text = $"Cubes left: {_cubesCreator.listOfCubes.Count}";
    }

    private void NextScene()
    {
        _isNextScene = true;
    }
}
