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
<<<<<<< HEAD
            // Recup le rigidbody du joueur
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Applique une force sur l'axe X
=======
            // On recup le rigidbody2D du joueur
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // On applique la jumpForce a l'axe X le forcant à faire un saut
>>>>>>> 436eacf9bccf272bbb64994bab217258e2b46ab5
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
<<<<<<< HEAD
=======

>>>>>>> 436eacf9bccf272bbb64994bab217258e2b46ab5
        animator.SetBool("IsBouncing", false);
        isBouncing = false;
    }
}