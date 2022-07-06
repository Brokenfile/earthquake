using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public float moveSpeed = 0.5f;
   

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
        
       if (movement != Vector2.zero)
    {
         animator.SetFloat("Horizontal", movement.x);
         animator.SetFloat("Vertical", movement.y);
    }
     animator.SetFloat("Speed", movement.sqrMagnitude);
     
    }




    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
