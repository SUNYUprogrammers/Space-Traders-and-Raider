using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    Text info;
    private void OnMouseDown()
    {
        info = GameObject.Find("Text").GetComponent<Text>();
        info.text = "There are three types of resources in the game, and the player will need to collect all three in large quantities if they want to have a chance at building anything substantial. These three materials are Cobalt (Which is the most common), Duranium (Which is rarer), and Adamantium (Which is the rarest). \n" +
"When colonizing a star system, it can result in being one of four different colors, each one providing the player a different amount of resources based on it’s color. \n" +
"Green - 30 Cobalt, 20 Duranium, 10 Adamantium \n" +
"Yellow - 20 Cobalt, 20 Duranium, Adamantium \n" +
"Blue - 0 Cobalt, 50 Duranium, 0 Adamantium \n" +
"Red - 0 Cobalt, 0 Duranium, 50 Adamantium";
    }
}
