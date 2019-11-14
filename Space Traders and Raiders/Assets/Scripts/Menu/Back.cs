using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream

public class Back : MonoBehaviour
{
    Camera OCamera;
    Camera Main;
    Camera LoadC;
    private void OnMouseDown()
    {
        //print("Back");//This is left in for future debugging
        OCamera = GameObject.Find("OptionCamera").GetComponent<Camera>();
        Main = GameObject.Find("Main Camera").GetComponent<Camera>();
        LoadC = GameObject.Find("LoadCamera").GetComponent<Camera>();
        Main.enabled = true;
        OCamera.enabled = false;
        LoadC.enabled = false;
=======
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    //Camera OCamera;
    //Camera Main;
    //Camera LoadC;
    private void OnMouseDown()
    {
        //print("Back");//This is left in for future debugging
        //OCamera = GameObject.Find("OptionCamera").GetComponent<Camera>();
        //Main = GameObject.Find("Main Camera").GetComponent<Camera>();
        //LoadC = GameObject.Find("LoadCamera").GetComponent<Camera>();
        //Main.enabled = true;
        //OCamera.enabled = false;
        //LoadC.enabled = false;
        SceneManager.LoadScene("MainMenu");
>>>>>>> Stashed changes
    }
}
