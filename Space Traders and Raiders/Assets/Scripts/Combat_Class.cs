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
    bool Switchsides = false;
    int spota;
    int spotd;
    
     int[,] attlist = new int [5,10]; //damaged = 1, destroyed = 0 for both
     int[,] deflist = new int [5,10];

     public Button aone;
     public Button atwo;
     public Button athree;
     public Button afour;
     public Button afive;
     public Button bone;
     public Button btwo;
     public Button bthree;
     public Button bfour;
     public Button bfive;
    
    int goods;
    int bads;
    int numofbeam, numofmissle, numofsheild, numofantimissle,numofarmor = 0;
    int loc;
    public void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>(); 
        //aone = GameObject.Find("aone").GetComponent<Button>();
        //bone = GameObject.Find("bone").GetComponent<Button>();
        //atwo = GameObject.Find("atwo").GetComponent<Button>();
        //btwo = GameObject.Find("btwo").GetComponent<Button>();
        //print(aone);
        //print(bone);

        
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

    public void count()
    {
        foreach(Ship_Class i in shipsStack)
        {
            print(i.faction);
            print(gm.currentPlayer.playerFaction);
            if(i.faction == gm.currentPlayer.playerFaction)
            {
                goods++;
            }
            else
            {
                bads++;
            }
        }
    }
    public void Combat()
    {
        
       // print(shipsStack.Length);
        Retreat();
        CombatUI.enabled = true;
        count();
        print(goods + "      " + bads);
        good = new Ship_Class[goods];
        bad = new Ship_Class[bads];
        //print("Size of good " + good.Length);
        //print("Size of bad " + bad.Length);
        //print("Combat");
        seprate(shipsStack);
        dica(good);
        dicd(bad);

        enableattackerbuttons();
        enabledefenderbuttons();
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
        CombatUI = GameObject.Find("CombatGUI").GetComponent<Canvas>();
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
                   // print(aone);
                    if(!Switchsides)
                    {
                        aone.interactable = false;
                    }
                    
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
                    if(Switchsides)
                    {
                        bone.interactable = false;
                    }
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
        //print(combat);
        if (combat)
        {
            //print(Switch);
            if (attacker != null && defender != null && Switchsides == false)//Attacker Turn(Initante Combat)
            {
                FindWeapons(attacker.parts_list);
                FindDefense(defender.parts_list);
                print(numofbeam + "  " + numofmissle + "  " + numofsheild + "   " + numofantimissle);
                int weaps = numofbeam + numofmissle;
                for (int i = 0; i < weaps; i++)
                {
                    if(numofbeam != 0)//check if they have a beam attack
                    {
                        numofbeam--;
                        if (Random.Range(0, 100) <= 50 /* || true*/)//chance of attacking, if its less then 50                        
                        {                          
                            if(numofsheild != 0)//do they have sheild
                            {
                                numofsheild--;
                                if(Random.Range(0,100) >= 50)//50% of blocking, if its more then 50 then block 
                                {
                                    print("Damage was blocked");
                                }
                                else//attacked
                                {
                                    print("Damage was done");
                                    if(numofarmor != 0)//armor has to be DESTROYED
                                    {
                                        print("armor is under attack");
                                        Findarmor(defender.parts_list);
                                        deflist[spotd,loc]--; //minus 1 health to armor
                                        if(deflist[spotd,loc] == 0)
                                        {
                                            numofarmor--;
                                        } 
                                    }
                                    else
                                    {
                                        print("Compoents under attack");
                                        int number = Random.Range(0,4); //this array stores def compoents health
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
                                }
                            }
                            else
                            {
                                print("Damage was done");
                                   if(numofarmor != 0)//armor has to be DESTROYED
                                    {
                                        print("armor is under attack");
                                        Findarmor(defender.parts_list);
                                        deflist[spotd,loc]--; //minus 1 health to armor
                                        if(deflist[spotd,loc] == 0)
                                        {
                                            numofarmor--;
                                        } 
                                    }
                                    else
                                    {
                                        print("Compoents under attack");
                                        int number = Random.Range(0,4); //this array stores def compoents health
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
                            }

                        }
                        else//this is acutally unneeded but is good for debugging
                        {
                            print("Attack missed");
                        }   
                    }
                    else if(numofmissle != 0)//Missile Attacks
                    {
                        if(Random.Range(0,100) >= 50)//50% of hitting with a hitting
                        {
                            if(numofantimissle != 0)//do they have an anti missile
                            {
                                if(Random.Range(0,100) <= 50)//50% of blocking
                                {
                                    print("Iron Dome activated");
                                }
                                else
                                {
                                    print("Damage was done");
                                    if(numofarmor != 0)
                                    {
                                        print("armor is under attack");
                                        Findarmor(defender.parts_list);
                                        numofarmor--;
                                        deflist[spotd,loc] = 1; 
                                    }
                                    else
                                    {
                                        print("Compoents under attack");
                                        int number = Random.Range(0,4); //this array stores def compoents health
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
                                }
                            }
                            else
                            {
                                print("Damage was done");
                                if(numofarmor != 0)//armor has to be DESTROYED
                                {
                                    print("armor is under attack");
                                    Findarmor(defender.parts_list);
                                    deflist[spotd,loc]--; //minus 1 health to armor
                                    if(deflist[spotd,loc] == 0)
                                    {
                                        numofarmor--;
                                    } 
                                }
                                else
                                {
                                    print("Compoents under attack");
                                    int number = Random.Range(0,4); //this array stores def compoents health
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
                            }
                        }
                        else
                        {
                            print("Your missiles were a dud");
                        }
                    }
                    
                }
                attacker.hasAttacked = true;
                attacker = null;
                defender = null;
                resetweaps();
            }//End Attacker attacks Defender
            int value = 0;
            foreach (Ship_Class i in good)
            {
                if(i.hasAttacked == true && i != null)
                {
                    value++;
                }
                if(value == good.Length)
                {
                    Switchsides = true;
                }
                
            }
           //print(Switchsides);
            if (attacker != null && defender != null && Switchsides == true)//Defender attacks Attacker
            {
                enableattackerbuttons();
                enabledefenderbuttons();
                print("defender turn");
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
                if (i.getType() == "Anti Missile")
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
                if(i.getType() == "Armour")
                {
                    i.dechealth();
                    break;
                }
            }
            loc++;
        }
    }

    public void enableattackerbuttons()
    {
        for(int i = 0;i < good.Length;i++)
        {
            //print(i);
            switch(i)
            {
                case 4:
                    afive.interactable = true;
                    break;
                case 3:
                    afour.interactable = true;
                    break;
                case 2:
                    athree.interactable = true;
                    break;
                case 1:
                    atwo.interactable = true;
                    break;
                case 0:
                    aone.interactable = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void enabledefenderbuttons()
    {
        for(int j = 0;j < bad.Length;j++)
        {
            //print(j);
            switch(j)
            {
                case 4:
                    bfive.interactable = true;
                    break;
                case 3:
                    bfour.interactable = true;
                    break;
                case 2:
                    bthree.interactable = true;
                    break;
                case 1:
                    btwo.interactable = true;
                    break;
                case 0:
                    bone.interactable = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void resetweaps()
    {
        numofantimissle = 0;
        numofarmor = 0;
        numofbeam = 0;
        numofmissle = 0;
        numofsheild = 0;
    }
   


}

   









