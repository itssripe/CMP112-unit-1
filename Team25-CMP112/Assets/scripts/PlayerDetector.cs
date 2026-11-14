using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMovement))]
public class PlayerDetector : MonoBehaviour
{

    [Header("Detection Area")]
    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectorSize = Vector2.one;
    public Vector2 detectorOffset = Vector2.one;

    private Rigidbody2D rb;
    //private Transform playerPos;

    public GameObject projectilePrefab; //Allows input for what projectile will be thrown
    public Transform throwPoint;

    public float throwTime;
    public float throwCounter;


    private Transform player;


    void Start()
    {
        rb= GetComponent<EnemyMovement>().Rb;
        throwCounter = throwTime;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D detector = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOffset, detectorSize, 0);
        Collider2D playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Collider;
        bool isPlayer = Physics2D.IsTouching(detector, playerCol);
        if (isPlayer)
        {
            if (throwCounter < 0)
            {
                Instantiate(projectilePrefab, (Vector2)throwPoint.position, Quaternion.identity);
                throwCounter = throwTime;
            }
        }
        throwCounter -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOffset, detectorSize);
    }
}
