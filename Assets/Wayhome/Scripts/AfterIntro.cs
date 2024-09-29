using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AfterIntro : MonoBehaviour
{
    public float timeLoad;

    // Update is called once per frame
    void Update()
    {
        timeLoad -= Time.deltaTime;
        if (timeLoad <= 0)
        {
            SceneManager.LoadScene("MenuGame");
        }
    }
}
