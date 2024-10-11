using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForcePrefabY : MonoBehaviour
{
    public float Force;
    public List<GameObject> myPrefabs;
    private List<Rigidbody2D> rigidbodies = new List<Rigidbody2D>();

    private void Start()
    {
        // Récup les Rigidbody2D de chaque prefab dans la liste
        foreach (GameObject prefab in myPrefabs)
        {
            Rigidbody2D rb = prefab.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rigidbodies.Add(rb);
            }
            else
            {
                Debug.LogError("Rigidbody2D not found on the prefab: " + prefab.name);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Applique Force sur Axe X
            foreach (Rigidbody2D rb in rigidbodies)
            {
                rb.velocity = new Vector2(Force, rb.velocity.y);
            }
        }
    }
}