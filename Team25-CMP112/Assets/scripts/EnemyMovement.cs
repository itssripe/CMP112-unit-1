using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MovementSpeed = 1f;
    private Vector2 startPos; //Gets enemy starting position on 2D axis

    private int facing = 1;

    private bool isFlipping;
    private bool isMoving = true;
    public float wait;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Gets rigidbody of the enemy character
        startPos = this.transform.position; //Gets the starting position of enemy
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFlipping && (transform.position.x > startPos.x + 0.5 || transform.position.x < startPos.x - 0.5))
        {
            isMoving = false;

            StartCoroutine(flip());
        }

        if (isMoving)
        {
            rb.linearVelocity = Vector2.right * facing * MovementSpeed;
        }
    }

    IEnumerator flip() //Flips the way the player is facing
    {
        wait += Time.deltaTime;

        isFlipping = true; //Character is flipping

        if (wait > 4)
        {
            Debug.Log("waited 4 seconds");
            transform.Rotate(0, 180, 0); //Flips character on y axis
            facing *= -1;
            yield return new WaitForSeconds(0.5f);
            isFlipping = false;
            stopped();
        }
    }

    void stopped()
    {
        isMoving = true;
        wait = 0;
    }
}
