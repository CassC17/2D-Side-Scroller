using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    public float jumpForce = 4f;         
    public float jumpHoldForce = 11f;    
    public float jumpTime = 0.3f;
    public float fallMultiplier = 2f;

    private float jumpTimer;
    private bool isJumping;
    private bool isGrounded;

    private int jumpCount = 0;
    public int maxJumps = 2;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // check if player is grounded and if one jump left
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
        {
            StartJump();
            jumpCount++;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            if (jumpTimer > 0)
            {
                rb.AddForce(Vector2.up * jumpHoldForce, ForceMode2D.Force);
                jumpTimer -= Time.fixedDeltaTime;
            }
            if (!isGrounded && !isJumping)
            {
                rb.AddForce(Vector2.down * fallMultiplier, ForceMode2D.Force);
            }
        }
    }

    private void StartJump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
        jumpTimer = jumpTime;
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verify on the layer or tag
        if (((1 << other.gameObject.layer) & groundLayer) != 0 || other.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;   // reset
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & groundLayer) != 0 || other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}



