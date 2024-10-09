using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public Transform cubeSpawnPoint;
    public GameObject cubePrefab;
    public float destroyDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
<<<<<<< HEAD
            // Crée le prefab au spawnpoint
=======
            // Créer un cube a la position du spawnPoint 
>>>>>>> 436eacf9bccf272bbb64994bab217258e2b46ab5
            GameObject cube = Instantiate(cubePrefab, cubeSpawnPoint.position, Quaternion.identity);

            // Détruire le cube après un délai
            if (destroyDelay > 0)
            {
                Destroy(cube, destroyDelay);
            }
            else
            {
                Destroy(cube);
            }

            gameObject.SetActive(false);
        }
    }
}