using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpHeight = 15f;
    public float moveSpeed = 5f;


    private float movement;
    private bool isGrounded;

    public Transform groundCheckPoint;
    public float groundCheckRadius = .2f;
    public LayerMask whatIsGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Collider2D collInfo = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (collInfo)
        {
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement * moveSpeed, 0f, 0f) *Time.fixedDeltaTime;
    }

    void Jump()
    {
        if (isGrounded)
        {
            Vector2 velocity = rb.linearVelocity;
            velocity.y = jumpHeight;
            rb.linearVelocity = velocity;
            isGrounded = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint == null)
        {
            return;
        }

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }
}
