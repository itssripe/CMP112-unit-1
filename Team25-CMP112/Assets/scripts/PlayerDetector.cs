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
        rb = GetComponent<EnemyMovement>().Rb;
        throwCounter = throwTime;
    }

    // Update is called once per frame
    void Update()
    {
        throwCounter -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (throwCounter < 0) //Checks if throwcounter is 0 or below and throws a projectile if true
            {
                Instantiate(projectilePrefab, (Vector2)throwPoint.position, Quaternion.identity); //Throws projectile from desired place on enemy
                throwCounter = throwTime;
            }
        }
    }
}
