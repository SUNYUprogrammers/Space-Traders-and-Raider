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


    public Canvas CombatUI;
    public void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    public void Combat(Ship_Class[] shipStack)
    {
        CombatUI.GetComponent<Canvas>().enabled = true;

        print("Combat");
        good = new Ship_Class[shipStack.Length];
        bad = new Ship_Class[shipStack.Length];

        seprate(shipStack);
        
    }

    private void seprate(Ship_Class[] shipStack)
    {
        int z = 0;
        int y = 0;
        foreach (Ship_Class i in shipStack)
        {
           if(i != null)
           {
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

    public void attack(int placeinarray)
    {

    }
}
