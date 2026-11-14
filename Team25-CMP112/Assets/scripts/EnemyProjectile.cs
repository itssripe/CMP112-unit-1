using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed = 1f; //Speed of projectile

    GameObject playerPos;

    public float projectileLife = 3f; //How long the projectile will exist for after being thrown/Created
    public float projectileCount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        projectileCount = projectileLife;

        playerPos = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveProjectile = (playerPos.transform.position - transform.position) * speed;
        projectileRb.linearVelocity = new Vector2(moveProjectile.x, (moveProjectile.y * 0)); //Shoots projectile straight forward
    }

    // Update is called once per frame
    void Update()
    {
        if(projectileCount <= 0) //Destroys thrown projectile when three seconds have passed
        {
            Destroy(this.gameObject);
            projectileCount = projectileLife;
        }
        projectileCount -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject); //Destroys player object when hit by projectile
        }
    }
}
