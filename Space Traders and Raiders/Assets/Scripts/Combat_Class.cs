using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//combat Version 1 , Notable things not included: No ship compents or Ship Targetting added
//Next possible version can include ship targeting 
public class Combat_Class : MonoBehaviour
{
    GameManager gm;
    [SerializeField]
    Ship_Class[] good;
    [SerializeField]
    Ship_Class[] bad;

    public void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    public void Combat(Ship_Class[] shipStack)
    {
        print("Combat");
        float hitchance = Random.Range(0,100);
        float blockchance = Random.Range(0,100);

        good = new Ship_Class[shipStack.Length];
        bad = new Ship_Class[shipStack.Length];

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
        z = 0;
        foreach(Ship_Class b in good)
        {
            if(b != null)
            {
                if(hitchance < 50)
                {
                    if(blockchance < 50)
                    {
                        print(b.name + " has destroyed " + bad[z].name);
                        Destroy(bad[z].gameObject);
                    }
                    else
                    {
                        print(bad[z] + " has survived the battle");
                    }
                }
                else
                {
                    print(bad[z] + " has survived the battle ");
                }
                z++;
            }
        }
    }
}
