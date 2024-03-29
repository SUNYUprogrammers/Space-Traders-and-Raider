﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Working on crying but more tears
//Stuff to fix
// --Create dica/b lists to include the current health of each compoment, this allows for any damaged compoents to carry over into next fights. 
//  --Create a Function for both Attacker/Defender being attack to increase efficently
// --Possibly find a better way of storing <Ship_Class>,<Component_Class> damage values Like [Ship_Class][Component]

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

    public Sprite Menu;
    public Sprite ButtonImage;
    bool combat = false;
    bool Switchsides = false;

    bool endofround = false;
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
    
    public Button EndCombatbut;
    public Text Combattext;
    int goods;
    int bads;
    int numofbeam, numofmissle, numofsheild, numofantimissle,numofarmor,number,attrows,attcolms,defrows, defcolms  = 0;
    int loc;

    bool allzeros1 = false;
    bool allzeros2 = false;

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


    public void count()
    {
        goods = 0;
        bads = 0;
        foreach(Ship_Class i in shipsStack)
        {
            
           // print(i.faction);
            //print(gm.currentPlayer.playerFaction);
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
    public void Combat(Ship_Class[] shipsInStack, int len)
    {
        shipsStack = new Ship_Class[len];
        shipsStack = shipsInStack;
        // print(shipsStack.Length);
        CombatUI.enabled = true;
        count();
       // print(goods + "      " + bads);
        good = new Ship_Class[goods];
        bad = new Ship_Class[bads];
        print("Size of good " + good.Length);
        print("Size of bad " + bad.Length);
        //print("Combat");
        seprate(shipsStack);
        dica(good);
        dicd(bad);
        Combattext.text = good[0].faction + " is on the <color=red>attack</color>";
        enableattackerbuttons();
        enabledefenderbuttons();
        Switchsides = false;
        combat = true;

       /* for (int i = 0; i <= good.Length; i++)
            print(good[i].name);*/
    }

    private void dica(Ship_Class[] ss)//haha germany get it
    {
        foreach(Ship_Class i in ss)
        {
            if(i != null)
            {
                attcolms = 0;
                foreach(Component_Class d in i.parts_list)
                {
                //print(d);
                    attlist[attrows,attcolms] = 1;
                    attcolms++;
                }
                attrows++;
            }
        }
        
    }

    private void dicd(Ship_Class[] bb)
    {
         
        foreach(Ship_Class i in bb)
        {
            if(i != null)
            {
                defcolms = 0;
                foreach(Component_Class d in i.parts_list)
                {
                    deflist[defrows,defcolms] = 1;
                    defcolms++;
                }
                defrows++;

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
                    good[z] = i;//ATTACKER
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
        good = null;
        bad = null;
    }

    public void enableEndCombat()
    {
        if(Switchsides)
        {
            EndCombatbut.GetComponent<Image>().sprite = Menu;
            EndCombatbut.interactable = false;
            EndCombatbut.GetComponentInChildren<Text>().text = " ";
        }
        else
        {
            EndCombatbut.GetComponent<Image>().sprite = ButtonImage;
            EndCombatbut.interactable = true;
            EndCombatbut.GetComponentInChildren<Text>().text = "End Combat";
        }
    }

    public void GetAttackerShip(int place)
    {
        
            switch (place)
            {
                case 0:
                    print(good[place].name);
                    attacker = good[place];
                    spota = place;
                   // print(aone);
                    if(!Switchsides)
                    {
                        aone.interactable = false;
                        
                    }
                    
                    break;
                case 1:
                    attacker = good[place];
                    spota = place;
                    if(!Switchsides)
                    {
                        atwo.interactable = false;
                    }
                    break;
                case 2:
                    attacker = good[place];
                    spota = place;
                   // print(aone);
                    if(!Switchsides)
                    {
                        athree.interactable = false;
                    }
                    break;
                case 3:
                    attacker = good[place];
                    spota = place;
                   // print(aone);
                    if(!Switchsides)
                    {
                        afour.interactable = false;
                    }
                    break;
                case 4:
                    attacker = good[place];
                    spota = place;
                   // print(aone);
                    if(!Switchsides)
                    {
                        afive.interactable = false;
                    }
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
                    defender = bad[place];
                    spotd = place;
                    if(Switchsides)
                    {
                        btwo.interactable = false;
                    }
                    break;
                case 2:
                     defender = bad[place];
                    spotd = place;
                    if(Switchsides)
                    {
                        bone.interactable = false;
                    }
                    break;
                case 3:
                     defender = bad[place];
                    spotd = place;
                    if(Switchsides)
                    {
                        bone.interactable = false;
                    }
                    break;
                case 4:
                     defender = bad[place];
                    spotd = place;
                    if(Switchsides)
                    {
                        bone.interactable = false;
                    }
                    break;


            }
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
               
                print("Attacker Turn");
                enableattackerbuttons();
                enabledefenderbuttons();
                FindWeapons(attacker.parts_list);
                FindDefense(defender.parts_list);
                print(numofbeam + "  " + numofmissle + "  " + numofsheild + "   " + numofantimissle);
                if(numofbeam == 0 && numofmissle == 0)
                    allzeros1 = true;
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
                                        number = Random.Range(0,defender.parts_list.Length - 1); //this array stores def compoents health
                                        switch(deflist[spotd,number]) 
                                        {
                                            case 1: 
                                                deflist[spotd,number] = 0;//Component has been destroyed
                                                 print(deflist[spotd,number] + "Component has been destroyed");
                                                break;
                                            default:
                                                 deflist[spotd,number] -= 1;//Ship takes a hull hit
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
                                        number = Random.Range(0,defender.parts_list.Length - 1); //this array stores def compoents health
                                        switch(deflist[spotd,number]) 
                                        {
                                           case 1: 
                                                deflist[spotd,number] = 0;//Component has been destroyed
                                                 print(deflist[spotd,number] + "Component has been destroyed");
                                                break;
                                            default:
                                                 deflist[spotd,number] -= 1;//Ship takes a hull hit
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
                        numofmissle--;
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
                                        deflist[spotd,loc]--; //minus 1 health to armor
                                        if(deflist[spotd,loc] == 0)
                                        {
                                            numofarmor--;
                                        } 
                                    }
                                    else
                                    {
                                        print("Compoents under attack");
                                        number = Random.Range(0,defender.parts_list.Length - 1); //this array stores def compoents health
                                        switch(deflist[spotd,number]) 
                                        {
                                            case 1: 
                                                deflist[spotd,number] = 0;//Component has been destroyed
                                                 print(deflist[spotd,number] + "Component has been destroyed");
                                                break;
                                            default:
                                                 deflist[spotd,number] -= 1;//Ship takes a hull hit
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
                                    number = Random.Range(0,defender.parts_list.Length - 1); //this array stores def compoents health
                                    switch(deflist[spotd,number]) 
                                    {
                                        case 1: 
                                                deflist[spotd,number] = 0;//Component has been destroyed
                                                 print(deflist[spotd,number] + "Component has been destroyed");
                                                break;
                                            default:
                                                 deflist[spotd,number] -= 1;//Ship takes a hull hit
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
                    
                }//end for loop
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
                     enableEndCombat();
                     Combattext.text = bad[0].faction + " is on the <color=red>attack</color>";
                    //Combattext.text = players.
                }
                
            }
            //print(Switchsides);
            if (attacker != null && defender != null && Switchsides == true)//Defender attacks Attacker
            {
                enableattackerbuttons();
                enabledefenderbuttons();
                print("defender turn");
                FindWeapons(defender.parts_list);
                FindDefense(attacker.parts_list);
                print(numofbeam + "  " + numofmissle + "  " + numofsheild + "   " + numofantimissle);
                if(numofbeam == 0 && numofmissle == 0)
                    allzeros2 = true;
                int weaps = numofbeam + numofmissle;
                for(int i = 0; i < weaps;i++)
                {
                    if(numofbeam != 0)
                    {
                        numofbeam--;
                        if(Random.Range(0,100) <= 50)
                        {
                            if(numofsheild !=0)
                            {
                                numofsheild--;
                                if(Random.Range(0,100) >= 50)//50% of blocking, if its more then 50 then block 
                                {
                                    print("Damage was blocked");
                                }
                                else
                                {
                                     print("Damage was done");
                                    if(numofarmor != 0)//armor has to be DESTROYED
                                    {
                                        
                                        print("armor is under attack");
                                        Findarmor(attacker.parts_list);
                                        attlist[spota,loc]--; //minus 1 health to armor
                                        if(attlist[spota,loc] == 0)
                                        {
                                            numofarmor--;
                                        } 
                                    }
                                    else//after armor is destroyed
                                    {
                                        print("Compoents under attack");
                                        number = Random.Range(0,attacker.parts_list.Length -1); //this array stores def compoents health
                                        switch(attlist[spota,number]) 
                                        {
                                            
                                            case 1: 
                                                attlist[spota,number] = 0;//Component has been destroyed
                                                 print(attlist[spotd,number] + "Component has been destroyed");
                                                break;
                                            default:
                                                attlist[spota,number] -= 1;//Ship takes a hull hit
                                                 print(attlist[spota,number] + "Ship took a hull hit");
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
                                        Findarmor(attacker.parts_list);
                                        attlist[spota,loc]--; //minus 1 health to armor
                                        if(attlist[spota,loc] == 0)
                                        {
                                            numofarmor--;
                                        } 
                                    }
                                    else
                                    {
                                        print("Compoents under attack");
                                        int number = Random.Range(0,attacker.parts_list.Length -1); //this array stores def compoents health
                                        switch(attlist[spota,number]) 
                                        {
                                            case 1: 
                                                attlist[spota,number] = 0;//Component has been destroyed
                                                 print(attlist[spotd,number] + "Component has been destroyed");
                                                break;
                                            default:
                                                attlist[spota,number] -= 1;//Ship takes a hull hit
                                                 print(attlist[spota,number] + "Ship took a hull hit");
                                                break;
                                        }
                                    }
                            }
                        }
                        else
                        {
                            print("Defender Attack missed");
                        }
                    }
                    else if(numofmissle != 0)
                    {
                        numofmissle--;
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
                                        Findarmor(attacker.parts_list);
                                        attlist[spota,loc]--; //minus 1 health to armor
                                        if(attlist[spota,loc] == 0)
                                        {
                                            numofarmor--;
                                        } 
                                    }
                                    else
                                    {
                                        print("Compoents under attack");
                                        number = Random.Range(0,attacker.parts_list.Length -1); //this array stores def compoents health
                                        switch(attlist[spota,number]) 
                                        {
                                            case 1: 
                                                attlist[spota,number] = 0;//Component has been destroyed
                                                 print(attlist[spotd,number] + "Component has been destroyed");
                                                break;
                                            default:
                                                attlist[spota,number] -= 1;//Ship takes a hull hit
                                                 print(attlist[spota,number] + "Ship took a hull hit");
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                 print("Damage was done");
                                    if(numofarmor != 0)
                                    {
                                        print("armor is under attack");
                                        Findarmor(attacker.parts_list);
                                         attlist[spota,loc]--; //minus 1 health to armor
                                        if(attlist[spota,loc] == 0)
                                        {
                                            numofarmor--;
                                        } 
                                    }
                                    else
                                    {
                                        print("Compoents under attack");
                                        number = Random.Range(0,attacker.parts_list.Length -1); //this array stores def compoents health
                                        switch(attlist[spota,number]) 
                                        {
                                           case 1: 
                                                attlist[spota,number] = 0;//Component has been destroyed
                                                 print(attlist[spotd,number] + "Component has been destroyed");
                                                break;
                                            default:
                                                attlist[spota,number] -= 1;//Ship takes a hull hit
                                                 print(attlist[spota,number] + " Ship took a hull hit");
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
                }//endforloop
                defender.hasAttacked = true;
                attacker = null;
                defender = null;
                resetweaps();
                //good.Clear(good,0,goods);
                //bad.Clear(bad,0,bads);
                 endofround = true;
            }
           
            value = 0;
            foreach (Ship_Class i in bad)
            {
                if(i.hasAttacked == true && i != null)
                {
                    value++;
                }
                if(value == bad.Length)
                {
                    Switchsides = false;
                    Combattext.text = good[0].faction + " is on the <color=red>attack</color>";
                    enableEndCombat();
                }
                
            }
            resetattackbools();

            if(endofround)
                calcdamges(); //good spot
            if(!combat)// this acutally  can't happen due to clac damages not fully impletented
            {
                good = null;
                bad = null;
                //endofround = false;
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
                   // i.dechealth();
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
                    afive.GetComponent<Image>().sprite = ButtonImage;
                    afive.GetComponentInChildren<Text>().text  = good[4].ship_type;
                    break;
                case 3:
                    afour.interactable = true;
                    afour.GetComponent<Image>().sprite = ButtonImage;
                    afour.GetComponentInChildren<Text>().text  = good[3].ship_type;
                    break;
                case 2:
                    athree.interactable = true;
                    athree.GetComponent<Image>().sprite = ButtonImage;
                    athree.GetComponentInChildren<Text>().text  = good[2].ship_type;
                    break;
                case 1:
                    atwo.interactable = true;
                    atwo.GetComponent<Image>().sprite = ButtonImage;
                    atwo.GetComponentInChildren<Text>().text  = good[1].ship_type;
                    break;
                case 0:
                    aone.interactable = true;
                    aone.GetComponent<Image>().sprite = ButtonImage;
                    aone.GetComponentInChildren<Text>().text  = good[0].ship_type;
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
                    bfive.GetComponent<Image>().sprite = ButtonImage;
                    bfive.GetComponentInChildren<Text>().text  = good[4].ship_type;
                    break;
                case 3:
                    bfour.interactable = true;
                    bfour.GetComponent<Image>().sprite = ButtonImage;
                    bfour.GetComponentInChildren<Text>().text  = good[3].ship_type;
                    break;
                case 2:
                    bthree.interactable = true;
                    bthree.GetComponent<Image>().sprite = ButtonImage;
                    bthree.GetComponentInChildren<Text>().text  = good[2].ship_type;
                    break;
                case 1:
                    btwo.interactable = true;
                    btwo.GetComponent<Image>().sprite = ButtonImage;
                    btwo.GetComponentInChildren<Text>().text  = good[1].ship_type;
                    break;
                case 0:
                    bone.interactable = true;
                    bone.GetComponent<Image>().sprite = ButtonImage;
                    bone.GetComponentInChildren<Text>().text  = good[0].ship_type;
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

    public void resetattackbools()
    {
        foreach(Ship_Class i in shipsStack)
        {
            if(i != null)
            {
                i.hasAttacked = false;
            }
        }
    }
   


   //WORK ON INTERFACEING WITH SHIP_CLASS AND COMPOENT_CLASS
    public void calcdamges()
    {
        int numofgood = goods;
        int numofbad = bads;
        print("CALC DAMAGES");
        if(allzeros1 && allzeros2)//if both have no weapons after 1 round end
        {
            combat = false;
            CombatUI.enabled = false;
            return;
        }
        for(int i = 0; i < defrows;i++)
        {
            for(int j = 0; j < defcolms;j++)
            {
                 //print("DEFENDER LOOP" + i + " " + j);
                switch(deflist[i,j])
                {
                    case 1:
                        //full health do nothing
                        continue;
                    case 0:
                        bad[i].parts_list[j] = null;   //compoent is destroyed but no hull hits
                        continue;
                    default: //any number < 0
                        for(int z = deflist[i,j];z < 0;z++)
                        {
                            bad[i].power--;
                            if(bad[i].power == 0)
                            {
                                GameObject.Destroy(bad[i].gameObject);
                                bad[i] = null;
                                print("destroy ship");
                                
                            }
                        }
                        //Compoenet is disabled + ship takes a hull hit --In current game state(Frigates only) this signels end of combat
                        continue;

                        
                }
                
            }
        }

        for(int i = 0; i < attrows;i++)
        {
            for(int j = 0; j < attcolms;j++)
            {
                //print("ATTACK LOOP" + i + " " + j);
                 switch(attlist[i,j])
                {
                    case 1:
                        //do nothing
                        continue;
                    case 0:
                         good[i].parts_list[j] = null;   //compoent is destroyed but no hull hits
                        continue;
                    default:
                        for(int z = attlist[attrows,attcolms];z < 0;z++)
                        {
                            good[i].power--;
                            if(good[i].power == 0)
                            {
                                print("destroy ship");
                                GameObject.Destroy(good[i].gameObject);
                                good[i] = null;
                            }
                        }
                        //Compoenet is disabled + ship takes a hull hit --In current game state(Frigates only) this signels end of combat
                        continue; 
                }
            }
        }
        endofround = false;
        print( allzeros1 + "  " + allzeros2);
        foreach(Ship_Class i in good)
        {
            if(i == null)
                numofgood--;
        }
        foreach(Ship_Class j in bad)
        {
            if(j == null)
                numofbad--;
        }
        print(numofgood + " " + numofbad);
        if((numofgood == 0 || numofbad == 0))//check if either array is destroyed, ships are destroyed in switch functions
        {
            combat = false;
            CombatUI.enabled = false;
        }
    }

   

}

    



   















//I did it mom