using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadScene : MonoBehaviour
{
    public string sceneToLoad = "WayHome";

    public void Start()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
