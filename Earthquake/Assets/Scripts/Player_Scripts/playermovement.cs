using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
   
    public float moveSpeed = 0.5f;
    public float armor;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            moveSpeed = 3f;
            Attack();
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
