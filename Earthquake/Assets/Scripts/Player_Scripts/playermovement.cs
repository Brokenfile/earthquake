using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
   
    public float moveSpeed = 0.5f;
    public float armor;

    public Rigidbody2D rb;
    public Animator animator;


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    Vector2 movement;

    // Update is called once per frame
    void Update()
    {   if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                moveSpeed = 3f;
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
        
       if (movement != Vector2.zero)
    {
         animator.SetFloat("Horizontal", movement.x);
         animator.SetFloat("Vertical", movement.y);
    }
     animator.SetFloat("Speed", movement.sqrMagnitude);
     
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Ennemy>().TakeDamage(attackDamage);

        }

    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
       //ur mom
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }


    void FixedUpdate() 
    {
        animator.SetFloat("Armor", 1f);
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime); 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 1f;
            animator.SetFloat("realSpeed", 1f);
        }
        else{
            moveSpeed = 0.5f;
            animator.SetFloat("realSpeed", 0.5f);
        }
      
    }
}
