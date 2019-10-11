using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_Class : MonoBehaviour
{

    protected int commonMineral = 100;
    protected int rareMineral = 60;
    protected int veryRareMineral = 40;
    protected StarSystem homeSystem;
    protected int Wealth = 0, Power = 0, Achievement = 0;
    public string playerFaction;
    public Ship_Class[] playerShips = new Ship_Class[5];
    public bool currentTurn = false;

    //Determines what ships the player owns
    public Ship_Class[] getPlayerShips(string faction)
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
        return playerShips;
    }

    //Sets player's name
    public void setPlayerFaction(string playerName)
    {
        playerFaction = playerName;
    }


    //Increments Resources based on Home System
    public void setResources(StarSystem sys)
    {
        if (sys != homeSystem)
        {
            switch (sys.type)
            {
                case MapGenerator.SystemType.GREEN:
                    commonMineral += 30;
                    rareMineral += 20;
                    veryRareMineral += 10;
                    print("stuff");
                    break;
                case MapGenerator.SystemType.YELLOW:
                    commonMineral += 20;
                    rareMineral += 20;
                    veryRareMineral += 20;
                    print("stuff");
                    break;
                case MapGenerator.SystemType.BLUE:
                    rareMineral += 50;
                    print("stuff");
                    break;
                case MapGenerator.SystemType.RED:
                    veryRareMineral += 50;
                    print("stuff");
                    break;
                default:
                    print("ERROR!");
                    break;
            }
        }
        else
        {
            commonMineral += 50;
            rareMineral += 30;
            veryRareMineral += 20;
            print("stuff");
        }
    }
    

    public void Start()
    {
        playerFaction = "Ron";
        getPlayerShips(playerFaction);
    }

    private int getCommonMineral()
    {
        return commonMinerals;
    }
    private int getRareMineral()
    {
        return rareMinerals;
    }
    private int getVeryRareMineral()
    {
        return veryRareMinerals;
    }
    private int getWealth()
    {
        return Wealth;
    }
    private int getPower()
    {
        return Power;
    }
    private int getAchievement()
    {
        return Achievement;
    }


}
