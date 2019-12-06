using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Text info;
    private void OnMouseDown()
    {
        info = GameObject.Find("Text").GetComponent<Text>();
        /*info.text = "During your turn, you can move any ships that you currently have control over. The speed of those ships is decided by the number of engines equipped to the ship at it’s current time. You are not required to move the full length of a ship’s movement speed during a turn, and you can end a turn with multiple of your own ships occupying the same space. It is possible to, if you are on the edge of a map, to travel to the opposite side of the board, as if the map was a globe. \n" 
    + "If your ship ends it’s turn on the same space an enemy ship is, a battle will begin(See Combat Rules). \n"
	+ "Controls: \n"
    + "Select a ship by clicking on its tile, (You can hold shift and click on an additional space to select more than one ship at a time). If you click on a tile with more than one ship on it, it will select the one at the top of the stack.Every additional click after that will select the ship one lower in the stack. You can double click on a tile with multiple ships on it to select them all at once. \n"
    + "When a ship is selected, all the areas that it can move too will light up green. If you right click that space, it will move to that location.If you have multiple ships selected, the only tiles that will light up green are the spaces that ALL selected ships can move to.If moving to a tile would initiate combat, that tile will be flashing bright red. \n";
    */

        if(info.text == "During your turn, you can move any ships that you currently have control over. The speed of those ships is decided by the number of engines equipped to the ship at it’s current time. You are not required to move the full length of a ship’s movement speed during a turn, and you can end a turn with multiple of your own ships occupying the same space. It is possible to, if you are on the edge of a map, to travel to the opposite side of the board, as if the map was a globe. \n")
        {
            info.text = "If your ship ends it’s turn on the same space an enemy ship is, a battle will begin(See Combat Rules). \n"
    + "Controls: \n"
    + "Select a ship by clicking on its tile, (You can hold shift and click on an additional space to select more than one ship at a time). If you click on a tile with more than one ship on it, it will select the one at the top of the stack.Every additional click after that will select the ship one lower in the stack. You can double click on a tile with multiple ships on it to select them all at once. \n";
        } else if(info.text == "If your ship ends it’s turn on the same space an enemy ship is, a battle will begin(See Combat Rules). \n"
    + "Controls: \n"
    + "Select a ship by clicking on its tile, (You can hold shift and click on an additional space to select more than one ship at a time). If you click on a tile with more than one ship on it, it will select the one at the top of the stack.Every additional click after that will select the ship one lower in the stack. You can double click on a tile with multiple ships on it to select them all at once. \n")
        {
            info.text = "When a ship is selected, all the areas that it can move too will light up green. If you right click that space, it will move to that location.If you have multiple ships selected, the only tiles that will light up green are the spaces that ALL selected ships can move to.If moving to a tile would initiate combat, that tile will be flashing bright red. \n";
        } else
        {
            info.text = "During your turn, you can move any ships that you currently have control over. The speed of those ships is decided by the number of engines equipped to the ship at it’s current time. You are not required to move the full length of a ship’s movement speed during a turn, and you can end a turn with multiple of your own ships occupying the same space. It is possible to, if you are on the edge of a map, to travel to the opposite side of the board, as if the map was a globe. \n";
        }
    }
}
