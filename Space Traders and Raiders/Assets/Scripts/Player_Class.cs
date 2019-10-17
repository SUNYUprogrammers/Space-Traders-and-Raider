using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_Class : MonoBehaviour
{
    protected GameManager gm;
    [SerializeField]protected int commonMineral = 100;
    [SerializeField] protected int rareMineral = 60;
    [SerializeField] protected int veryRareMineral = 40;
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
            switch (sys.getType())
            {
                case MapGenerator.SystemType.GREEN:
                    commonMineral += 30;
                    rareMineral += 20;
                    veryRareMineral += 10;
                    print("GREEN");
                    break;
                case MapGenerator.SystemType.YELLOW:
                    commonMineral += 20;
                    rareMineral += 20;
                    veryRareMineral += 20;
                    print("YELLOW");
                    break;
                case MapGenerator.SystemType.BLUE:
                    rareMineral += 50;
                    print("BLUE");
                    break;
                case MapGenerator.SystemType.RED:
                    veryRareMineral += 50;
                    print("RED");
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
            print("HOME");
        }
    }

    public int getCommonMineral()
    {
        return commonMineral;
    }
    public int getRareMineral()
    {
        return rareMineral;
    }
    public int getVeryRareMineral()
    {
        return veryRareMineral;
    }
    public int getWealth()
    {
        return Wealth;
    }
    public int getPower()
    {
        return Power;
    }
    public int getAchievement()
    {
        return Achievement;
    }
    public int calcVictoryPoints()
    {
        Wealth = commonMineral / 10;
        Wealth += (rareMineral/10)*2;
        Wealth += (veryRareMineral / 10) * 3;
        Power = 0;
        foreach (Ship_Class temp in playerShips)
        {
            if(temp != null) {
                Power += temp.power;
            }
        }
        Achievement = 1;

        return (Wealth + Power + Achievement);
    }

    public void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        getPlayerShips(playerFaction);
    }

    public void Update()
    {
        if(this.homeSystem == null)
        {
            this.homeSystem = gm.getVacantSystem();
            homeSystem.owner = this;
            print(homeSystem.getPosition());
            GameObject temp = Instantiate((GameObject)Resources.Load("HomeSystem"), homeSystem.getTransform());
            switch (this.playerFaction)
            {
                case "Player1":
                    temp.GetComponent<SpriteRenderer>().color = new Color(1,0,1,1);
                    break;

                case "Player2":
                    temp.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 1);
                    break;
            }
        }
    }

    public void winCon()
    {
        if ((Wealth >= 50) && (Power >= 50) && (Achievement >= 50))
        {
            print(playerFaction + " Wins");
        }
    }
}
