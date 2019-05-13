﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Manages the links between each scene
/// The method LoadScene(string) loads the scene with the name given as a string parameter
/// For example, to load the "ShipAR" scene --> Manager.LoadScene("ShipAR");
/// </summary>

public class Manager : MonoBehaviour
{
    // loads the scene with the name sceneName
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
