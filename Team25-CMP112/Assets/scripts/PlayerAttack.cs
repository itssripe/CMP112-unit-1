using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer sr;
    private bool CanHitAgain;
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

        animator.Play("Attack_sword");

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CanHitAgain = false;
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
