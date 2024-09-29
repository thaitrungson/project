using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 40;
    bool canMove = false;

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(transform.localScale.x, -2) * Speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canMove = collision.gameObject.tag == "ground";
    }
}
