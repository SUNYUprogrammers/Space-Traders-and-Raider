using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas menu;

    private Ship_Class[] array;
    int num;

    public void Combat()
    {
        Combat_Class bat = GameObject.FindObjectOfType<Combat_Class>();
        bat.Combat(array, num);
        Cancel();
    }

    public void Trade()
    {
        //rons crap
        Cancel();
    }

    public void Cancel()
    {
        menu.enabled = false;
    }

    public void Menu(Ship_Class[] shipsInStack,int len)
    {
        menu.enabled = true;
        array = shipsInStack;
        num = len;
        
    }
}
