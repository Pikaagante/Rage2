using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

<<<<<<< HEAD
=======

>>>>>>> 436eacf9bccf272bbb64994bab217258e2b46ab5
public class End : MonoBehaviour
{
    public string Level;

<<<<<<< HEAD
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
=======
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
>>>>>>> 436eacf9bccf272bbb64994bab217258e2b46ab5
        {
            SceneManager.LoadScene(Level);
        }
    }
}
