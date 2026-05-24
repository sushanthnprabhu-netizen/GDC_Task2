using UnityEngine;

public class Task3_PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jump")]
    public float jumpForce = 7f;

    public int maxJumpCount = 2;

    [Header("Ground Check")]
    public Transform groundCheck;

    public LayerMask groundLayer;

    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;

    private float moveInput;

    private bool isGrounded;

    private int jumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput =
            Input.GetAxisRaw("Horizontal");

        CheckGround();

        if (
            Input.GetButtonDown("Jump")
            && jumpCount < maxJumpCount
        )
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        rb.velocity =
            new Vector2(
                moveInput * moveSpeed,
                rb.velocity.y
            );
    }

    void CheckGround()
    {
        isGrounded =
            Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );

        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    void Jump()
    {
        rb.velocity =
            new Vector2(
                rb.velocity.x,
                jumpForce
            );

        jumpCount++;
    }
}