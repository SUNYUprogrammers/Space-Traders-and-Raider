using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Working on crying but more tears.

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
    int spota;
    int spotd;
    
     int[,] attlist = new int [5,10]; //damaged = 1, destroyed = 0 for both
     int[,] deflist = new int [5,10];
    
    int numofbeam, numofmissle, numofsheild, numofantimissle,numofarmor = 0;
    int loc;
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
       // print(shipsStack.Length);
        Retreat();
        CombatUI.enabled = true;
        good = new Ship_Class[shipsStack.Length];
        bad = new Ship_Class[shipsStack.Length];
        //print("Size of good " + good.Length);
        //print("Size of bad " + bad.Length);
        //print("Combat");
        seprate(shipsStack);
        dica(good);
        dicd(bad);
        combat = true;

       /* for (int i = 0; i <= good.Length; i++)
            print(good[i].name);*/
    }

    private void dica(Ship_Class[] ss)//haha germany get it
    {
        int y = 0;
        int z = 0;
        foreach(Ship_Class i in ss)
        {
            if(i != null)
            {
                foreach(Component_Class d in i.parts_list)
                {
                //print(d);
                    attlist[y,z] = 2;
                    z++;
                }
                y++;
                z = 0;
            }
        }
    }

    private void dicd(Ship_Class[] bb)
    {
        int y = 0;
        int z = 0;
        foreach(Ship_Class i in bb)
        {
            if(i != null)
            {
                foreach(Component_Class d in i.parts_list)
                {
                    attlist[y,z] = 2;
                    z++;
                }
                y++;
                z=0;
            }
            
        }
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
                    //print(good[place].name);
                    attacker = good[place];
                    spota = place;
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
                    //print(bad[place].name);
                    defender = bad[place];
                    spotd = place;
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
        print(combat);
        if (combat)
        {
            //print(Switch);
            if (attacker != null && defender != null && Switch == false)//Attacker Turn(Initante Combat)
            {
                FindWeapons(attacker.parts_list);
                FindDefense(defender.parts_list);
                print(numofbeam + "  " + numofmissle + "  " + numofsheild + "   " + numofantimissle);
                for (int i = 0; i <= (numofbeam + numofmissle); i++)
                {
                    if (Random.Range(0, 100) <= 50 /* || true*/)//chance of attacking, if its less then 50
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
                                    if(numofarmor >= 0)
                                    {
                                        print("armor is under attack");
                                        Findarmor(defender.parts_list);
                                        numofarmor--;
                                        deflist[spotd,loc] = 1; 
                                    }
                                    else
                                    {
                                        print("Compoents under attack");
                                        int number = Random.Range(0,4);
                                        switch(deflist[spotd,number])
                                        {
                                            case 2:
                                                deflist[spotd,number] = 1;//Compoent has lost 1 health
                                                print(deflist[spotd,number] + "has lost 1 health");
                                                break;
                                            case 1: 
                                                deflist[spotd,number] = 0;//Component has been destroyed
                                                 print(deflist[spotd,number] + "Component has been destroyed");
                                                break;
                                            default:
                                                deflist[spotd,number] = -1;//Ship takes a hull hit
                                                 print(deflist[spotd,number] + "Ship took a hull hit");
                                                break;
                                            
                                        }
                                    }
                                
                                    numofbeam--;
                                    numofsheild--;
                                }
                            }

                        }
                        if(numofmissle != 0)
                        {

                        }
                    }
                    else//this is acutally unneeded but is good for debugging
                    {
                        print("Attack missed");
                    }
                }
                attacker = null;
                defender = null;
            }//End Attacker attacks Defender
            if (attacker != null && defender != null && Switch == true)//Defender attacks Attacker
            {

            }


        }
    }

    public void FindDefense(Component_Class[] parts)//find 
    {
        foreach(Component_Class i in parts)
        {
            if (i != null)
            {
                //print(i.getType());
                if (i.getType() == "Shield")
                {
                    numofsheild++;
                }
                if (i.getType() == "Anti Missle")
                {
                    numofantimissle++;
                }
                if(i.getType() == "Armour")
                {
                    numofarmor++;
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
                //print(i.getType());
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

    public void Findarmor(Component_Class[] parts)//use for both
    {
        foreach(Component_Class i in parts)
        {
            if(i != null)
            {
                if(i.getType() == "Armor")
                {
                    i.dechealth();
                    break;
                }
            }
            loc++;
        }
    }

   


}

   









