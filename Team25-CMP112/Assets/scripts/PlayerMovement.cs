using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementVector;
    private Vector2 jumpVector;
    public float MovementSpeed;
    public float jumpForce = 5f;
    private bool jumped;
    private bool onGround;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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