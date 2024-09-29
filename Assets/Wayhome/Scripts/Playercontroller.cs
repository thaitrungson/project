using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Playercontroller : MonoBehaviour
{
    public ParticleSystem dust;


    public float maxSpeed;
    public float jumpHeight;
    bool facingRight;
    bool grounded;
    public AudioSource aus;
    public AudioClip CherrySound;


    public Transform gunTip;
    public GameObject Bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;


    Rigidbody2D myBody;
    Animator myAnim;

    private GameObject currentTeleport;

    GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
        gc = FindObjectOfType<GameController>();
    }





    // Update is called once per frame
    void FixedUpdate()
    {
        dostmao();
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
        if (move > 0 && !facingRight)
        {
            flip();
        } else if (move < 0 && facingRight)
        {
            flip();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
            }
        }

        if //(Input.GetAxisRaw("Fire1") > 0)
            (Input.GetKey(KeyCode.R))
            fireBullet();
          
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.B))
        {
            if(currentTeleport != null)
            {
                Thread.Sleep(30);
                transform.position = currentTeleport.GetComponent<Teleport>().GetDestination().position;
            }
        }
    }







    //quay mặt nhân vật
    void flip()
    {
        dostmao();
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }

        /*  if(gc.SetGameoverState(true))
           {
                maxSpeed = 0;
               jumpHeight = 0;
           }*/


    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("DeathZone"))
        {
            gc.SetGameoverState(true);
            Destroy(gameObject);
           
        }
        if(collider.CompareTag("house"))
        {
            gc.SetGamevictoryState(true);
            //myBody = !myBody;
            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("Cherry"))
        {
            gc.IncrementScore();
            aus.PlayOneShot(CherrySound);
            
        }

        if (collider.gameObject.CompareTag("Gem"))
        {
            gc.IncrementScore5();
            aus.PlayOneShot(CherrySound);

        }

        if(collider.gameObject.CompareTag("Teleport"))
        {
            currentTeleport = collider.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Teleport"))
        {
            if(collider.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
        }
    }
    
    
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(Bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(Bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }

    public void dostmao()
    {
        dust.Play();
    }
   

}
