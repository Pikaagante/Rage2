using UnityEngine;
using System.Collections.Generic;

public class SpawnPrefabList : MonoBehaviour
{
    public List<Transform> spawnPoints; // Liste des points de spawn
    public GameObject prefab;
    public float destroyDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                // Crée le prefab au spawnpoint aux différents points
                GameObject instance = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

                // Détruire l'instance après un délai
                if (destroyDelay > 0)
                {
                    Destroy(instance, destroyDelay);
                }
                else
                {
                    Destroy(instance);
                }
            }

            gameObject.SetActive(false);
        }
    }
}