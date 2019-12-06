using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raiding : MonoBehaviour
{
    Text info;
    private void OnMouseDown()
    {
        info = GameObject.Find("Text").GetComponent<Text>();
        if(info.text == "If a player initiates an attack against a ship owned by a player that hasn’t been labeled a raider, or on a system owned by another player, they receive a “raider penalty” for 10 turns. The number of turns refreshes if they already had the penalty.")
        {
            info.text = "Being labeled a raider comes with a few negative effects. Most significantly, players with the penalty cannot take advantage of trade centers, meaning they must bring a ship into another player’s system if they want to trade with them, and other player’s must do the same to trade with them. Raiders also open themselves up to being attacked by other players, because initiating an attack against a raider will not give the attacker the raider penalty.";
        } else if (info.text == "Being labeled a raider comes with a few negative effects. Most significantly, players with the penalty cannot take advantage of trade centers, meaning they must bring a ship into another player’s system if they want to trade with them, and other player’s must do the same to trade with them. Raiders also open themselves up to being attacked by other players, because initiating an attack against a raider will not give the attacker the raider penalty.")
        {
            info.text = "Situationally, being a raider can be very beneficial. Intercepting trade ships and raiding other player’s systems can be very profitable for you and detrimental to others. In addition, players with the raider penalty can ‘cannibalize’ enemy ships after combat- meaning any modules on the ship that were still intact can be moved onto an open slot on their own ship.";
        }
        else
        {
            info.text = "If a player initiates an attack against a ship owned by a player that hasn’t been labeled a raider, or on a system owned by another player, they receive a “raider penalty” for 10 turns. The number of turns refreshes if they already had the penalty.";
        }
    }
}
