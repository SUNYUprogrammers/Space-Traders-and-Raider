using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    Camera OCamera;
    Camera Main;
    private void OnMouseDown()
    {
        //print("Options");//This is left in for future debugging
        OCamera = GameObject.Find("OptionCamera").GetComponent<Camera>();
        Main = GameObject.Find("Main Camera").GetComponent<Camera>();
        Main.enabled = false;
        OCamera.enabled = true;
    }
}
