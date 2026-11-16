using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
   
    private Animator animator;
    private SpriteRenderer sr;
    private bool CanHitAgain;


    public GameObject Arrow_Projectile;
    public bool IsAttacking;
    public bool SwordEquipped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        CanHitAgain = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }







    private void OnAttack(InputValue Value)
    {

        if (SwordEquipped)
        {
            animator.Play("Attack_sword");
        }
        else
        {
            animator.Play("Attack_bow");
            Instantiate(Arrow_Projectile, transform.position, transform.rotation);
        }

    }


    private void OnEquip(InputValue Value)//changes between sword and bow
    {
        if (SwordEquipped)
        {
            SwordEquipped = false;

        }
        else
        {
            SwordEquipped = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CanHitAgain = false; // probably better on enemy
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CanHitAgain = true;
        }
    }
}
