using UnityEngine;

public class ProjectileThrow : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform throwPoint;

    public bool seePlayer;

    public float throwTime;
    public float throwCounter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        throwCounter = throwTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (seePlayer && throwCounter < 0)
        {
            Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);
            throwCounter = throwTime;
        }
        throwCounter -= Time.deltaTime;
    }
}
