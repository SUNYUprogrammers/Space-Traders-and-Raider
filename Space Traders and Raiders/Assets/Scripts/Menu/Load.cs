using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    //Camera LoadC;
    //Camera Main;
    //GameObject preFab;

    //void Start()
    //{
    //    preFab = GameObject.Find("optionsBackdrop");
    //    preFab.rectTransform.position = new Vector3(-2,-1.1,-6.1);
    //}

    private void OnMouseDown()
    {
        //print("Load");//This is left in for future debugging
        //LoadC = GameObject.Find("LoadCamera").GetComponent<Camera>();
        //Main = GameObject.Find("Main Camera").GetComponent<Camera>();
        //Main.enabled = false;
        //LoadC.enabled = true;
        SceneManager.LoadScene("LoadMenu");
    }
}
