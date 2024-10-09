using System.Collections;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float jumpForce = 10f; // Force de saut 
    public Animator animator;
    public AudioSource audioSource;
    private bool isBouncing = false; // Variable pour éviter les sauts repetes

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si detecte Player et si ne saute pas
        if (other.CompareTag("Player") && !isBouncing)
        {
            // Recup le rigidbody du joueur
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // On applique la jumpForce a l'axe X le forcant à faire un saut
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if (animator != null)
            {
                isBouncing = true;
                animator.SetBool("IsBouncing", true);
                StartCoroutine(ResetBounceAnimation());
            }

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    private IEnumerator ResetBounceAnimation()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        animator.SetBool("IsBouncing", false);
        isBouncing = false;
    }
}