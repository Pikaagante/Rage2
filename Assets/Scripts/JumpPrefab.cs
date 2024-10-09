using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPrefab : MonoBehaviour
{
    public float jumpForce = 10f;
    public GameObject myPrefab;

    private Rigidbody2D rb;

    private void Start()
    {
        // Recup le rigidbody du prefab
        rb = myPrefab.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on the prefab.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (rb != null)
            {
                // Applique une force sur l'axe X du prefab
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}