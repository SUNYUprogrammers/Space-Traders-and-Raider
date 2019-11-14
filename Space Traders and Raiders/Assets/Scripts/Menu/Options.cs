using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    //Camera OCamera;
    //Camera Main;
    private void OnMouseDown()
    {
        //print("Options");//This is left in for future debugging
        //OCamera = GameObject.Find("OptionCamera").GetComponent<Camera>();
        //Main = GameObject.Find("Main Camera").GetComponent<Camera>();
        //Main.enabled = false;
        //OCamera.enabled = true;
        SceneManager.LoadScene("OptionMenu");
    }
}
