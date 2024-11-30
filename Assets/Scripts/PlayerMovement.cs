using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 15f;
    private int jumpCount = 0;
    private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rb2d.gravityScale = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHorizontalMovement();
        HandleJumpInput();
        UpdateAnimation();
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(movement.x * speed, rb2d.linearVelocity.y);
    }

    private void HandleJumpInput()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jumpCount < 2)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }

    private void HandleHorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontalInput, rb2d.linearVelocity.x);
        if (horizontalInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void UpdateAnimation()
    {
        bool hasInput = Mathf.Abs(Input.GetAxis("Horizontal")) > 0;
        bool isRunning = Mathf.Abs(rb2d.linearVelocity.x) > 0f;
        animator.SetBool("isRunning", isRunning || hasInput);
    }
}

