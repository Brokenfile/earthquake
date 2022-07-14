using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        //Debug.Log("Enemy died!");
        GetComponent<Collider2D>().enabled = false;
        transform.localScale = new Vector3(0, 0, 0);
        this.enabled = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
