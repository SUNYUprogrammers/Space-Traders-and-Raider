using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//combat Version 1 , Notable things not included: No ship compents or Ship Targetting added
//Next possible version can include ship targeting 
public class Combat_Class : MonoBehaviour
{
    public void Combat(Ship_Class[] shipStack)
    {
        print("Combat");
        float hitchance = Random.Range(0,100);
        float blockchance = Random.Range(0,100);
        int z = 0;
        int y = 0;
        Ship_Class[] good = new Ship_Class[shipStack.Length];
        Ship_Class[] bad = new Ship_Class[shipStack.Length];

       
        
        foreach(Ship_Class i in shipStack)
        {
           if(i != null)
           {
               if((i.faction == "Player1") || (i.faction == "Player2"))//get current faction (edited to work with ship types player class uses)
                {
                    good[z] = i;
                     z++;
                }
                else
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
