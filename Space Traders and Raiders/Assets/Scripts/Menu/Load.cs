using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    Camera LoadC;
    Camera Main;
    private void OnMouseDown()
    {
        //print("Load");//This is left in for future debugging
        LoadC = GameObject.Find("LoadCamera").GetComponent<Camera>();
        Main = GameObject.Find("Main Camera").GetComponent<Camera>();
        Main.enabled = false;
        LoadC.enabled = true;
    }
}
