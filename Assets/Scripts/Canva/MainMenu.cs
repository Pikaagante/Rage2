using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelStart;

    public GameObject settingsWindow;

    public GameObject LevelsWindow;


    public void StartGame()
    {
        SceneManager.LoadScene(levelStart);
    }
    public void LevelsActive()
    {
        LevelsWindow.SetActive(true);
    }
    public void LevelsClose()
    {
        LevelsWindow.SetActive(false);
    }
    public void Settings()
    {
        settingsWindow.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }

    public void Leave()
    {
        Application.Quit();
    }
}
