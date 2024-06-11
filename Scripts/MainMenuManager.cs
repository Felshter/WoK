using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene(1);
    }

    public void continueGame()
    {
        if (SaveManager.SaveFileExists())
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogWarning("No save file found");
        }
    }

    public void quit()
    {
        Application.Quit();
    }
}
