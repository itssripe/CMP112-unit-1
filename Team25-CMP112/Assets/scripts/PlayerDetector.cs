using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public GameObject projectilePrefab; //Allows input for what projectile will be thrown
    public Transform throwPoint;

    public float throwTime;
    public float throwCounter;


    public float lineOfSight; //Allows the distance of line of sight to be changed
    private Transform player;


    void Start()
    {
        throwCounter = throwTime;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position,transform.position);
        if (distanceFromPlayer < lineOfSight)
        {
            if (throwCounter < 0)
            {
                Instantiate(projectilePrefab, (Vector2)throwPoint.position, Quaternion.identity);
                throwCounter = throwTime;
            }
        }
        throwCounter -= Time.deltaTime;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
