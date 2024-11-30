using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private int maxJumpCounts = 2;
    private int jumpCount = 0;
    private int holdedWeapon = 0;
    
    private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private DialogueManager dialogueManager;
    [SerializeField] private EquipmentSystem equipmentSystem;
    public PlayerAttack attackComponents;
    
    //Sliding
    [SerializeField] private bool isWallSliding;
    [SerializeField] private float wallSlidingSpeed;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    
    //Wall Jumping
    private bool isWallJumping;
    private float wallJumpingDirection;
    [Range(0, 1)]
    [SerializeField] private float wallJumpingTime = 0.2f;

    private float wallJumpingCounter = 0.5f;
    [SerializeField] private Vector2 wallJumpingPower = new Vector2(8f, 16f);
    
    [SerializeField] private float wallJumpingDuration = 0.5f;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        attackComponents = GetComponent<PlayerAttack>();

        equipmentSystem = GetComponentInChildren<EquipmentSystem>();
    }

    void Start()
    {
        rb2d.gravityScale = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        // if (dialogueManager.isDialogueActive) return;
        if (equipmentSystem.GetPanel().activeSelf)
        {
            StopPlayer();
            UpdateAnimation();
            return;
        }
        HandleHorizontalMovement();
        HandleJumpInput();
        UpdateAnimation();
        WallSlide();
        WallJump();
        Cast();
    }

    void FixedUpdate()
    {
        if (equipmentSystem.GetPanel().activeSelf)
        {
            StopPlayer();
            UpdateAnimation();
            return;
        }
        rb2d.linearVelocity = new Vector2(movement.x * speed, rb2d.linearVelocity.y);
        
    }

    private void HandleJumpInput()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jumpCount < maxJumpCounts)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            jumpCount++;
        }
    }

    private void Cast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attackComponents.castSpell();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            attackComponents.stopCasting();
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled())
        {
            Debug.Log("Walled");
            isWallSliding = true;
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, Mathf.Clamp(rb2d.linearVelocity.y, -wallSlidingSpeed,  float.MaxValue));
        }
        else isWallSliding = false;
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallSliding = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0)
        {
            isWallJumping = true;
            rb2d.linearVelocity = new Vector2(wallJumpingDirection  * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;
            //rotate
            if (transform.localScale.x != wallJumpingDirection)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }

    public void StopPlayer()
    {
        rb2d.linearVelocity = Vector2.zero;
    }
    private void HandleHorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontalInput, rb2d.linearVelocity.x);
        if (!isWallJumping)
        {
            if (horizontalInput > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (horizontalInput < 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }

       
    }

    private void UpdateAnimation()
    {
        bool hasInput = Mathf.Abs(Input.GetAxis("Horizontal")) > 0f;
        bool isRunning = Mathf.Abs(rb2d.linearVelocity.x) > 0f;
        animator.SetBool("isRunning", isRunning || hasInput);
    }
}

