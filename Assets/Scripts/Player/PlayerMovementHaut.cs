using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHaut : MonoBehaviour
{
    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    public float moveSpeed;
    public float jumpForce;

    public Transform spawnPoint; // Point de spawn

    void Start()
    {
        // Ajuster la position initiale du joueur pour qu'il soit au point de spawn
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }

        // Inverser la gravité
        rb.gravityScale = -1;

        // Inverser le sprite
        spriteRenderer.flipY = true;
    }

    void Update()
    {
        // Vérifiez si le joueur est au plafond (sol inversé)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
        MovePlayer(horizontalMovement);

        if (isJumping && isGrounded)
        {
            rb.AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse); // Sauter vers le bas
            isJumping = false;
        }
    }

    void MovePlayer(float horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}