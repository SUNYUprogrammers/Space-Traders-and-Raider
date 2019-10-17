using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        print("Back to menu");
        SceneManager.LoadScene("MainMenu");
    }
}
