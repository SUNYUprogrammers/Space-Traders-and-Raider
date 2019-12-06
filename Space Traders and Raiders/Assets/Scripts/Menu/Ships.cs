using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ships : MonoBehaviour
{
    Text info;
    private void OnMouseDown()
    {
        info = GameObject.Find("Text").GetComponent<Text>();
        info.text = "There are two parts to every ship: the hull and its modules. There are five different hulls, each with more space for modules and more health than the last: \n" +
"1.Frigate - 5 Module Slots, 2 Health \n" +
"2.Destroyer - 10 Module Slots, 5 Health \n" +
"3.Cruiser - 15 Module Slots, 9 Health \n" +
"4.Battleship - 20 Modules Slots, 12 Health \n" +
"5.Dreadnought - 25 Module Slots, 15 Health \n" +
"To see how to build ships check out the building section";
    }
}
