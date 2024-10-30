using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    public string[] levelNames;

    private void Start()
    {
        UpdateLevelButtons();
    }

    public void UpdateLevelButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Button button = levelButtons[i];
            if (button == null)
            {
                continue;
            }

            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText == null)
            {
                continue;
            }

            if (LevelManager.IsLevelUnlocked(levelNames[i]))
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
                buttonText.color = Color.gray;
            }

            int index = i;
            button.onClick.AddListener(() => {
                LoadLevelPassed(levelNames[index]);
            });
        }
    }

    public void LoadLevelPassed(string level)
    {
        SceneManager.LoadScene(level);
    }
}