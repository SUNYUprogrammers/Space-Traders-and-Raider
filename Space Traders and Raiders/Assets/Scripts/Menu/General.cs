using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class General : MonoBehaviour
{
    Text info;
    private void OnMouseDown()
    {
        info = GameObject.Find("Text").GetComponent<Text>();
        /*info.text = "Space Traders and Raiders is a digital take on the beloved board game of the same name. It is a competitive multiplayer strategy game in which players build up a space empire in an effort to control the galaxy. A player wins the game through one of three conditions: \n" + 
"1. If they are the only player who controls at least one system, they win. \n" +
"2. If one player controls more than half of the game board, they win. \n" +
"3. If a player has obtained enough victory points, they win. \n" +
"A player is determined to be the victor if they have they meet one of the three required conditions above. A special indicator appears if they are set to win the game on their next turn. \n" +
"Victory Points \n" +
"There are three types of victory points players can earn: \n" +
"1. Wealth \n" +
"•	Determined by the number of resources the player currently owns \n" +
"o Every 10 Cobalt are worth 1 point \n" +
"o   Every 10 Duranium are worth 2 points \n" +
"o   Every 10 Adamantium are worth 3 points \n" +
"2. Power \n" +
"•	Determined by the number of systems and ships the player currently owns \n" +
"o Every system is worth 5 points \n" +
"o   Ships are worth 1 to 5 points based on their size(Frigate is 1 point; Dreadnought is 5 points) \n" +
"3. Achievement \n" +
"•	Determined by the number of facilities you own and their tech level \n" +
"o Each facility is worth 1 point per tech level \n" +
"To win, a player needs to have at least 50 points in each category. \n";*/

        if (info.text == "Space Traders and Raiders is a digital take on the beloved board game of the same name. It is a competitive multiplayer strategy game in which players build up a space empire in an effort to control the galaxy. A player wins the game through one of three conditions: \n" +
"1. If they are the only player who controls at least one system, they win. \n" +
"2. If one player controls more than half of the game board, they win. \n" +
"3. If a player has obtained enough victory points, they win. \n" +
"A player is determined to be the victor if they have they meet one of the three required conditions above. A special indicator appears if they are set to win the game on their next turn. \n")
        {
            info.text = "Victory Points \n" +
"There are three types of victory points players can earn: \n" +
"1. Wealth \n" +
"•	Determined by the number of resources the player currently owns \n" +
"o Every 10 Cobalt are worth 1 point \n" +
"o   Every 10 Duranium are worth 2 points \n" +
"o   Every 10 Adamantium are worth 3 points \n";
        } else if (info.text == "Victory Points \n" +
"There are three types of victory points players can earn: \n" +
"1. Wealth \n" +
"•	Determined by the number of resources the player currently owns \n" +
"o Every 10 Cobalt are worth 1 point \n" +
"o   Every 10 Duranium are worth 2 points \n" +
"o   Every 10 Adamantium are worth 3 points \n")
        {
            info.text = "2. Power \n" +
"•	Determined by the number of systems and ships the player currently owns \n" +
"o Every system is worth 5 points \n" +
"o   Ships are worth 1 to 5 points based on their size(Frigate is 1 point; Dreadnought is 5 points) \n";
        } else if(info.text == "2. Power \n" +
"•	Determined by the number of systems and ships the player currently owns \n" +
"o Every system is worth 5 points \n" +
"o   Ships are worth 1 to 5 points based on their size(Frigate is 1 point; Dreadnought is 5 points) \n")
        {
            info.text = "3. Achievement \n" +
"•	Determined by the number of facilities you own and their tech level \n" +
"o Each facility is worth 1 point per tech level \n" +
"To win, a player needs to have at least 50 points in each category. \n";
        } else
        {
            info.text = "Space Traders and Raiders is a digital take on the beloved board game of the same name. It is a competitive multiplayer strategy game in which players build up a space empire in an effort to control the galaxy. A player wins the game through one of three conditions: \n" +
"1. If they are the only player who controls at least one system, they win. \n" +
"2. If one player controls more than half of the game board, they win. \n" +
"3. If a player has obtained enough victory points, they win. \n" +
"A player is determined to be the victor if they have they meet one of the three required conditions above. A special indicator appears if they are set to win the game on their next turn. \n";
        }
    }
}
