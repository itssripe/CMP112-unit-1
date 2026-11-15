using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rigidbody2D Rb {
        get { return rb; }
        set { rb = value; }
    }

    public float MovementSpeed = 1f; //Enemy movement speed
    private Vector2 startPos; //Gets enemy starting position on 2D axis
    private Transform playerPos;
    public Transform PlayerPos
    {
        get { return playerPos; }
        set {  playerPos = value; }
    }

    private int facing = 1;
    
    private bool isFlipping;
    private bool isMoving = true;

    private float randomTime, timer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Gets rigidbody of the enemy character
        startPos = this.transform.position; //Gets the starting position of enemy

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        randomTime = Random.Range(1, 3); //Generates a random number between 1 and 3
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= randomTime)
        {
            change();
        }

        if (!isFlipping && (transform.position.x > startPos.x + 1.5 || transform.position.x < startPos.x - 1.5))
        {
            StartCoroutine(flip());
        }

        if (isMoving)
        {
            rb.linearVelocity = Vector2.right * facing * MovementSpeed;
        }
    }

    IEnumerator flip() //Flips the way the enemy is facing
    {
        isFlipping = true; //Enemy is flipping
        transform.Rotate(0, 180, 0); //Flips character on y axis
        facing *= -1;
        yield return new WaitForSeconds(0.5f);
        isFlipping = false; //Enemy is no longer flipping
    }

    void change()
    {
        isMoving = !isMoving;
        randomTime = isMoving ? Random.Range(1, 3) : Random.Range(1, 3); //If isWalking = true move for randomTime 1 to 3 or if isWalking = false stop for randomTime 1 to 3
        timer = 0; //Reset timer to 0
    }
}
