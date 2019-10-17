using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        Text inFunc = GameObject.Find("exit").GetComponent<Text>();
        inFunc.onClick.AddListener(TasksOnClick);
    }

    void TasksOnClick()
    {
        Debug.Log("Exited!");
        //Application.Quit();
    }*/

    void OnMouseDown()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
