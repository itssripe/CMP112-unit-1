using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed = 2f;

    public float projectileLife = 3;
    public float projectileCount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        projectileCount = projectileLife;
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        projectileRb.linearVelocity = new Vector2(speed, projectileRb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
