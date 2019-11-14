using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Working on ship targeting.

public class Combat_Class : Ship_Class
{

    GameManager gm;
    [SerializeField]
    Ship_Class[] good;
    [SerializeField]
    Ship_Class[] bad;


    public Canvas CombatUI;
    public Canvas Askcombat;
    public void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    public void askCombat()
    {
        Askcombat.GetComponent<Canvas>().enabled = true;
    }

    public void Retreat()
    {
        Askcombat.GetComponent<Canvas>().enabled = false;
    }

    public void Combat()
    {
        print(getShipsInStack().Length);
        Retreat();
        CombatUI.GetComponent<Canvas>().enabled = true;

        good = new Ship_Class[shipsInStack.Length];
        bad = new Ship_Class[shipsInStack.Length];

        print("Combat");
        
       

        seprate(shipsInStack);

       /* for (int i = 0; i <= good.Length; i++)
            print(good[i].name);*/
    }

    private void seprate(Ship_Class[] shipStack)
    {
        int z = 0;
        int y = 0;
        foreach (Ship_Class i in shipStack)
        {
           if(i != null)
           {
                print(i.faction + "          " + gm.currentPlayer.playerFaction);
                if(i.faction == gm.currentPlayer.playerFaction)
                {
                    good[z] = i;
                    z++;
                } else
                {
                    bad[y] = i;
                    y++;
                }
           }
        }
    }

    public void EndCombat()
    {
        CombatUI.GetComponent<Canvas>().enabled = false;
    }

    public void Update()
    {
        //lol
    }
    public void GetShip(int placeinarray)
    {
        
        
            switch (placeinarray)
            {
                case 0:
                    print(good[placeinarray].name);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;


            }
        
 
    }

    public void Attack(Ship_Class ship)
    {
        Ship_Class[] Attackarray = new Ship_Class[2];
    }
}
