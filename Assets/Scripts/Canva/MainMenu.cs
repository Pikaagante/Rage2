using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelStart;

    public GameObject settingsWindow;


    public void StartGame()
    {
        SceneManager.LoadScene(levelStart);
    }
    public void Levels()
    {

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
