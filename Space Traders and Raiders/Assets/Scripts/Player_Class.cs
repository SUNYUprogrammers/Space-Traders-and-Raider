using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_Class : MonoBehaviour
{

    protected int commonMineral = 50;
    protected int rareMineral = 30;
    protected int veryRareMineral = 20;
    protected int Wealth, Power, Achievement;
    string playerFaction;
    public Ship_Class[] playerShips = new Ship_Class[5];

    public void getPlayerShips(string faction)
    {
        Ship_Class[] temp;
        temp = GameObject.FindObjectsOfType<Ship_Class>();
        int j = 0;

        foreach (Ship_Class i in temp)
        {

            if (i.faction == playerFaction)
            {
                playerShips[j] = i;
                print(playerShips[j]);
                j++;
            }
        }
    }

    public void Start()
    {
        playerFaction = "Ron";
        getPlayerShips(playerFaction);
    }
}
