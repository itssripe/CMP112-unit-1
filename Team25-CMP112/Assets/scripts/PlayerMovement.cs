using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private Vector2 movementVector;
    private Vector2 jumpVector;
    private bool jumped;
    private bool onGround;
    public float MovementSpeed;
    public float jumpForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
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
        
        if (movementVector.x < 0)
        {
            sr.flipX = true;
        }
        if (movementVector.x > 0)
        {
            sr.flipX = false;
        }
        if (movementVector.x != 0)
        {
            animator.Play("Walk");
        }
        else if (movementVector.x == 0)
        {
            animator.Play("Idle");
        }
    }

    private void OnJump(InputValue Value)
    {
        if (onGround)
        {
            jumped = true;
        }
    }






    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = true;  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}