using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Working on ship targeting.

public class Combat_Class : MonoBehaviour
{

    GameManager gm;
    [SerializeField]
    Ship_Class[] good;
    [SerializeField]
    Ship_Class[] bad;

    [SerializeField]
    Ship_Class[] shipsStack;

    private Ship_Class attacker;
    private Ship_Class defender;
    public Canvas CombatUI;
    public Canvas Askcombat;
    public void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        
    }

    public void askCombat(Ship_Class[] shipsInStack,int len)
    {
        shipsStack = new Ship_Class[len];
        int j = 0;
        Askcombat.GetComponent<Canvas>().enabled = true;
        foreach(Ship_Class i in shipsInStack) 
        {
           // print("askcombat function    " + i);
            shipsStack[j] = i;
            //print("hope " + shipsStack[j]);
            j++;
            
        }
    }

    public void Retreat()
    {
        Askcombat.GetComponent<Canvas>().enabled = false;
    }

    public void Combat()
    {
        print(shipsStack.Length);
        Retreat();
        CombatUI.GetComponent<Canvas>().enabled = true;

        good = new Ship_Class[shipsStack.Length];
        bad = new Ship_Class[shipsStack.Length];

        print("Combat");
        seprate(shipsStack);

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
                //print(i.faction + "          " + gm.currentPlayer.playerFaction);
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

    public void GetAttackerShip(int place)
    {
        
        
            switch (place)
            {
                case 0:
                    print(good[place].name);
                    attacker = good[place];
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

    public void GetDefenderShip(int place)
    {
        
            switch (place)
            {
                case 0:
                    print(bad[place].name);
                    defender = bad[place];
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
    public void Attack()
    {
        print("does something still thinking bout it");
    }
}
