using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMovement))]
public class PlayerDetector : MonoBehaviour
{

    private Rigidbody2D rb;

    public GameObject projectilePrefab; //Allows input for what projectile will be thrown
    public Transform throwPoint;

    public float throwTime;
    public float throwCounter;


    void Start()
    {
        rb= GetComponent<EnemyMovement>().Rb;
        throwCounter = throwTime;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D detector = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<DetectionBox>().Detector; //Gets transforms of detector from Detection Box script
        Collider2D playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Collider;
        bool isPlayer = Physics2D.IsTouching(playerCol, detector); //Checks if player's collider is touching the PlayerDectorBox collider
        if (isPlayer)
        {
            if (throwCounter < 0) //Checks if throwcounter is 0 or below and throws a projectile if true
            {
                Instantiate(projectilePrefab, (Vector2)throwPoint.position, Quaternion.identity); //Throws projectile from desired place on enemy
                throwCounter = throwTime;
            }
        }
        throwCounter -= Time.deltaTime;
    }
}
