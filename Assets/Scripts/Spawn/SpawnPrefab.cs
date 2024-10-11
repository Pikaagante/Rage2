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
            // Créer un cube à la position du spawnPoint
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