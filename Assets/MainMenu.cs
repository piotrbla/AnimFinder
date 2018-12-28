﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void NewGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void DoQuit()
    {
        Application.Quit();
    }
}
