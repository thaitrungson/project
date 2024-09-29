using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookGap : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            enemy.transform.localScale =
           new Vector3(-enemy.transform.localScale.x,
           enemy.transform.localScale.y,
           enemy.transform.localScale.z);
        }

    }
}
