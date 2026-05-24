using UnityEngine;

public class Task2_PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7f;

    [Header("Jump")]
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        Jump();

        CheckGround();
    }

    void Move()
    {
        float moveInput =
            Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(
            moveInput * moveSpeed,
            rb.velocity.y
        );
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)
            && isGrounded)
        {
            rb.velocity =
                new Vector2(
                    rb.velocity.x,
                    jumpForce
                );
        }
    }

    void CheckGround()
    {
        isGrounded =
            Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );
    }
}