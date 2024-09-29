using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cherry : MonoBehaviour
{
    //public int cherryValue = 1;
    GameController gc;
    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            gc.IncrementScore();

        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
  
}
