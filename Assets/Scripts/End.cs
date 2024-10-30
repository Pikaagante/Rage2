using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string nextLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.UnlockLevel(nextLevel);
            SceneManager.LoadScene(nextLevel);
        }
    }
}