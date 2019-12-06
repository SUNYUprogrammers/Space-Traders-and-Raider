using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trading : MonoBehaviour
{
    Text info;
    private void OnMouseDown()
    {
        info = GameObject.Find("Text").GetComponent<Text>();
        
        if(info.text == "Players are able to trade resources with each other. To make a trade offer, a player needs to have loaded resources into an open slot on one of their ships and brought it within range of another player’s system. \n" +
"If two players have active trade centers with overlapping ranges, they can freely trade resources without the need of a ship.")
        {
            info.text = "Making a Trade Offer \n" +
"At any point in a player’s turn, they can send a trade offer to any other player.They can offer up to the number of resources they own, and can ask for up to the number of resources the other player owns.It is also possible for either side to offer nothing in a trade, allowing for players to give gifts or make demands. \n" +
"If an offer has been made to a player, during their turn they can decline, accept, or make a counter offer.To be able to accept a trade offer, one of the players must have a ship with enough resources to facilitate the trade in range of the other, or both must have active trade centers in range of each other.";
        } else
        {
            info.text = "Players are able to trade resources with each other. To make a trade offer, a player needs to have loaded resources into an open slot on one of their ships and brought it within range of another player’s system. \n" +
"If two players have active trade centers with overlapping ranges, they can freely trade resources without the need of a ship.";

        }
    }
}
