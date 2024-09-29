using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    bool facingRight;

    public float maxHealth;
    float currentHealth;


    void Start()
    {
         currentHealth = maxHealth;
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    //  nhận sát thương
    public void addDamage(float damage)
    {
        currentHealth -=  damage;
        if(currentHealth <=0)
            Destroy(gameObject);
    }
}
