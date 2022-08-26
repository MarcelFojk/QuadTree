using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Initialization : MonoBehaviour
{
    public static Action sceneLoaded;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void Start()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        sceneLoaded?.Invoke();
    }
}
