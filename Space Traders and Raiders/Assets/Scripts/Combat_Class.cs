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
    bool combat = false;
    bool Switch = false;

    int numofbeam, numofmissle, numofsheild, numofantimissle = 0;

    public void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>(); 
    }

    public void askCombat(Ship_Class[] shipsInStack,int len)
    {
        Askcombat.enabled = true;
        shipsStack = new Ship_Class[len];
        int j = 0;
        foreach(Ship_Class i in shipsInStack) 
        {
            //print("askcombat function    " + i);
            shipsStack[j] = i;
            //print("hope " + shipsStack[j]);
            j++;
            
        }
    }

    public void Retreat()
    {
        Askcombat.enabled = false;
    }

    public void Combat()
    {
        combat = true;
       // print(shipsStack.Length);
        Retreat();
        CombatUI.enabled = true;

        
        good = new Ship_Class[shipsStack.Length];
        bad = new Ship_Class[shipsStack.Length];

        //print("Size of good " + good.Length);
        //print("Size of bad " + bad.Length);
        //print("Combat");
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
                    //print(good[z].name);
                    z++;
                } else
                {
                    bad[y] = i;                   
                    //print(bad[y].name);
                    y++;
                }
           }
        }
    }

    public void EndCombat()
    {
        //if player == current.faction 
        CombatUI.enabled = false;
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


    // Engine -- ingore
    //Armour -- TARGET FIRST 
    //Beam -- 1 beam = 1 attack,2 beam = 2 attack etc
    //Sheild -- protects againist lasers 50% of blocking
    //Missile -- 1 missle = 1 attack, etc
    //Coloization Module -- ingore
    //Anti-Missile -- protects againist missiles 50% of blocking
    //System Repair Module --write last check GDD

    //do math after both sides attack






    public void Update()
    {
        //print("update combat");
        if (combat)
        {
            
            if (attacker != null && defender != null && Switch == false)//Attacker Turn(Initante Combat)
            {
                FindWeapons(attacker.parts_list);
                FindDefense(defender.parts_list);
                for (int i = 0; i <= (numofbeam + numofmissle); i++)
                {
                    if (Random.Range(0, 100) <= 50)//chance of attacking, if its less then 50
                    {
                        if(numofbeam != 0)//beam attack                        
                        {
                            if(numofsheild != 0)//do they have sheild
                            {
                                if(Random.Range(0,100) >= 50)//50% of blocking, if its more then 50 then block 
                                {
                                    print("Damage was blocked");
                                    numofbeam--;
                                    numofsheild--;
                                }
                                else//attacked
                                {
                                    print("Damage was done");
                                    numofbeam--;
                                    numofsheild--;
                                }
                            }

                        }
                        if(numofmissle != 0)
                        {

                        }
                    }
                }
            }       

        }
    }



    public void FindDefense(Component_Class[] parts)//find sheild
    {
        foreach(Component_Class i in parts)
        {
            if (i != null)
            {
                print(i.getType());
                if (i.getType() == "Sheild")
                {
                    numofsheild++;
                }
                if (i.getType() == "Anti Missle")
                {
                    numofantimissle++;
                }
            }
        }
    }

    public void FindWeapons(Component_Class[] parts)
    {
        foreach (Component_Class i in parts)
        {
            if (i != null)
            {
                print(i.getType());
                if (i.getType() == "Beam")
                {
                    numofbeam++;
                }
                if (i.getType() == "Missile")
                {
                    numofmissle++;
                }
            }
        }
    }


}

   









