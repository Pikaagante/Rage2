using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    private float resumeTime = 0.1f;
    private float timeSinceResume = 0f;

    public string level;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (!gameIsPaused)
        {
            timeSinceResume += Time.unscaledDeltaTime;
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        timeSinceResume = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public bool CanJump()
    {
        return timeSinceResume > resumeTime;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(level);
    }
}