using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private const string LevelKey = "Level_";

    private void Start()
    {
        InitializeLevels();
    }

    public static void InitializeLevels()
    {
        if (!PlayerPrefs.HasKey(LevelKey + "Level1"))
        {
            UnlockLevel("Level1");
        }
    }

    public static void UnlockLevel(string level)
    {
        PlayerPrefs.SetInt(LevelKey + level, 1);
        PlayerPrefs.Save();
    }

    public static bool IsLevelUnlocked(string level)
    {
        bool isUnlocked = PlayerPrefs.GetInt(LevelKey + level, 0) == 1;
        return isUnlocked;
    }

    public static void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void ResetProgressAndInitialize()
    {
        ResetProgress();
        InitializeLevels();
        SceneManager.LoadScene("Level1");
    }
}