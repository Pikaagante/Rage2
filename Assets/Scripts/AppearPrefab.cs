using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearPrefab : MonoBehaviour
{
    public GameObject Prefab;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = Prefab.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
        }
    }
}