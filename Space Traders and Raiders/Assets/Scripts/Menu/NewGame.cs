using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    //private AssetBundle myLoadedAssetBundle;
    //private string[] scenePaths;

    /*
    void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes/Compile");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }
    */

    private void OnMouseDown()
    {
        print("New game");//This is left in for future debugging
        SceneManager.LoadScene("Nov 15");
    }
}
