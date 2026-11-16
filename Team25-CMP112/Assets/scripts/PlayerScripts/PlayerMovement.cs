using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //declaration of variables
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private Vector2 movementVector;
    private Vector2 jumpVector;
    private PlayerAttack PlayerAttack;
    private bool jumped;
    private bool onGround;
    public float MovementSpeed;
    public float jumpForce = 5f;
    public bool isRunning;
    public bool IsLookingRight;

    private Collider2D collider;
    public Collider2D Collider
    {
        get { return collider; }
        set { collider = value; }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()//gets various components
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        PlayerAttack = GetComponent<PlayerAttack>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()//movement of the player 
    {
        Vector2 movement = new Vector2(movementVector.x, movementVector.y);
        rb.AddForce(movement * MovementSpeed);

        if (jumped)
        {
            jumped = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
        



    }

    private void OnMove(InputValue Value)
    {
        movementVector = Value.Get<Vector2>();

        if (movementVector.x < 0)//flip sprite
        {
            sr.flipX = true;
            IsLookingRight = false;
        }
        if (movementVector.x > 0)//flip sprite
        {
            sr.flipX = false;
            IsLookingRight = true;
        }
        if (movementVector.x != 0)//play walk animation
        {
            if (!PlayerAttack.IsAttacking)//if player is attacking, don't play walk animation
            {
                animator.Play("Walk");
            }
            
            isRunning = true;
        }
        else if (movementVector.x == 0)//play idle animation
        {
            if (!PlayerAttack.IsAttacking)
            {
                animator.Play("Idle");
            }
            isRunning = false;
        }
    }

    private void OnJump(InputValue Value)
    {
        if (onGround)//checks if on ground
        {
            jumped = true;
        }
    }






    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))//compares player collider with the ground collider if in contact - sets to true
        {
            onGround = true;  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))//compares player collider with the ground collider if not in contact - sets to false
        {
            onGround = false;
        }
    }
}