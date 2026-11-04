using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 movementVector;
    public float MovementSpeed = 1f;
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
        rb.linearVelocity = movementVector * MovementSpeed;

    }

    private void OnMove(InputValue Value)
    {
        movementVector = Value.Get<Vector2>();
    }
}
