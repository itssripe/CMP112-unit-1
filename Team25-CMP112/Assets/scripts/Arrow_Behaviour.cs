using UnityEngine;
using UnityEngine.InputSystem;

public class Arrow_Behaviour : MonoBehaviour
{
    public float MoveSpeed = 25f;
    private PlayerMovement playermovement;
    private SpriteRenderer sr;
    private bool moveRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playermovement = FindFirstObjectByType<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        moveRight = playermovement.IsLookingRight;
        Destroy(gameObject, 5f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveRight)
        {
            transform.position += transform.right * MoveSpeed * Time.fixedDeltaTime;
            sr.flipX = false;
        }
        else
        {
            transform.position -= transform.right * MoveSpeed * Time.fixedDeltaTime;
            sr.flipX = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
