using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float BulletSpeed;
    public float timedestroy;
    Rigidbody2D myBody;

    public float bulletDamage;



    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z > 0)
        {
            myBody.AddForce(new Vector2(-1, 0) * BulletSpeed, ForceMode2D.Impulse);
        }
        else
            myBody.AddForce(new Vector2(1, 0) * BulletSpeed, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timedestroy);
    }



    // Update is called once per frame
    void Update()
    {
        
    }



    //viên đạn dừng lại khi gặp enemy
    public void removeForce()
    {
        myBody.velocity = new Vector2(0, 0);
    }


    //viên đạn dừng lai, biến mất à gây sát thương khi chạm enemy 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="enemy")
        {
            removeForce();
            Destroy(gameObject);
            if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Enemy hurtEnemy = other.gameObject.GetComponent<Enemy>();
                hurtEnemy.addDamage(bulletDamage);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            removeForce();
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Enemy hurtEnemy = other.gameObject.GetComponent<Enemy>();
                hurtEnemy.addDamage(bulletDamage);
            }
        }
    }
}
