using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstallMenu : MonoBehaviour
{
    public Ship_Class selected_ship;
    public int selector = 0;
    public Ship_Class[] ships;

    public Shipyard_Class current;

    public int component_type;                  //0 = thrusters, 1 = armour, 2 = beam, 3 = shield, 4 = missile, 5 = colony, 6 = anti, 7 = repair
    public int[] inRange;                       //Components located in nearby spacedock, position in array referred to as above
    public Component_Class toInstall;

    public Text[] Ship_list;
    public Text[] parts_avail;

    public GameObject part2;
    public Image[] part_view;

    // Start is called before the first frame update
    void Start()
    {
        //Ship_list = new Text[8];
        inRange = new int[8];
    }

    // Update is called once per frame
    void Update()
    {
        //print("HEY");
        if (ships.Length == 0)                                                                      //Set array length, after ships are initialized in Start
        {
            //print("Hey " + GameObject.FindObjectsOfType<Ship_Class>().Length);
            ships = new Ship_Class[GameObject.FindObjectsOfType<Ship_Class>().Length];
        }

        if (true)                                                                                   //Find selected ships to populate ships[]
        {
            int j = 0;
            Ship_Class[] temp2 = GameObject.FindObjectsOfType<Ship_Class>();
            foreach (Ship_Class i in temp2)
            {
                if (i != null && i.selected == true)
                {
                    ships[j] = i;
                    j++;
                }
                else
                {
                    ships[j] = null;
                }
            }
        }
        //print(selector+" "+ships[selector]);
        if(ships[selector] != null)                                                                 //If button has ship associated with it, select it
        {
            selected_ship = ships[selector];
        }
        if(selected_ship != null)
        {
            //if(part2 != null)
                //print(part2.name + " " + (selected_ship.getShipType() + "(Clone)"));
            if (part2 == null || part2.name != (selected_ship.getShipType()+"(Clone)"))
            {
                part2 = Instantiate((GameObject)Resources.Load(selected_ship.getShipType()),this.transform);
                int h=0;
                foreach(Button i in part2.GetComponentsInChildren<Button>())
                {
                    print("Button " + i.name + " " + h);
                    i.onClick.AddListener(() => install(int.Parse(i.name)));
                    part_view[h] = i.GetComponent<Image>();
                    h++;
                }
            }

            int u = 0;
            //part_view = new Image[selected_ship.parts_list.Length];
            foreach(Component_Class i in selected_ship.parts_list)
            {
                if (i != null)
                {
                    part_view[u].sprite = i.getSprite();
                }
                u++;
            }
        }
        //print("What up?");
        if (Ship_list[0].GetComponentInParent<Canvas>().enabled == true)                            //If Canvas enabled, update UI
        {
            if (selected_ship != null)
            {
                Ship_list[0].text = selected_ship.name;
            }
            int k = 0;
            //print("YO " + ships[0]);
            foreach (Ship_Class i in ships)                                                         //Populate text for ships list
            {
                //print("YOU " + i.name);
                if (Ship_list[k+1] != null)
                {
                    //print("In if "+ships[k].name);
                    if (ships[k] != null)
                    {
                        //print("Fill text box "+Ship_list[k+1].name+ " with "+i.name);
                        Ship_list[k+1].text = i.name;
                        k++;
                    }
                    else
                    {
                        Ship_list[k+1].text = "";
                    }
                }
            }

            //print(selected_ship);
            if (selected_ship != null)                                                             //If Canvas enabled and ship is selected,                           
            {                                                                                      //Find faction Shipyard and available components
                bool temp3 = true;
                Shipyard_Class[] temp;
                temp = GameObject.FindObjectsOfType<Shipyard_Class>();
                foreach (Shipyard_Class i in temp)
                {
                    if (selected_ship.pos == i.GetComponent<Transform>().position && i.faction == selected_ship.faction)
                    {
                        print("truw");
                        inRange = i.component_storage;
                        current = i;
                        temp3 = false;
                    }
                }
                if (temp3 == true)                                                                       //If no shipyard found, set to -1
                {
                    inRange = new int[] { -1, -1, -1, -1, -1, -1, -1, -1 };
                    current = null;
                }
            }
            int p = 0;
            foreach (int i in inRange)
            {
                parts_avail[p].text = ""+i;
                p++;
            }
        }
        
    }

    public void setComponent(int i)
    {
        component_type = i;
    }

    public void setSelection(int i)
    {
        selector = i;
        if (ships[selector] == null)
        {
            selector = -1;
        }
    }

    public void install(int i)
    {
        print("Install " + component_type + " at slot " + i);
        if(selected_ship.parts_list[i] != null)
            print("To Replace "+ selected_ship.parts_list[i].getType());
        bool tmp = true;

        switch (component_type)                                                                     //FInd component to be installed, install, and reduce inv
        {
            case 0:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Thruster_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                    //current.component_storage[component_type]--;
                }
                else
                {
                    tmp = false;
                }
                break;
            case 1:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Armour_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                    //current.component_storage[component_type]--;
                }
                else
                {
                    tmp = false;
                }
                break;
            case 2:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Beam_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                    //current.component_storage[component_type]--;
                }
                else
                {
                    tmp = false;
                }
                break;
            case 3:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Shield_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                    //current.component_storage[component_type]--;
                }
                else
                {
                    tmp = false;
                }
                break;
            case 4:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Missile_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                    //current.component_storage[component_type]--;
                }
                else
                {
                    tmp = false;
                }
                break;
            case 5:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Colonization_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                    //current.component_storage[component_type]--;
                }
                else
                {
                    tmp = false;
                }
                break;
            case 6:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<AntiMissile_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                    //current.component_storage[component_type]--;
                }
                else
                {
                    tmp = false;
                }
                break;
            case 7:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Repair_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                    //current.component_storage[component_type]--;
                }
                else
                {
                    tmp = false;
                }
                break;
        }
        
        if(selected_ship.parts_list[i] != null)                                                 //If part is already in slot, refund type to inv
        {
            int temp = -1;
            //Debug.Break();
            selected_ship.parts_list[i].getType();
            switch(selected_ship.parts_list[i].getType())
            {
                case "Thruster":
                    temp = 0;
                    break;
                case "Armour":
                    temp = 1;
                    break;
                case "Beam":
                    temp = 2;
                    break;
                case "Shield":
                    temp = 3;
                    break;
                case "Missile":
                    temp = 4;
                    break;
                case "Colonization":
                    temp = 5;
                    break;
                case "Anti Missile":
                    temp = 6;
                    break;
                case "Repair":
                    temp = 7;
                    break;
            }
            //Increment and replace, does not reference shipyard yet
            if (temp != -1)
            {
                print("Replacing part " + temp + " from "+i);
                Destroy(selected_ship.parts_list[i]);
                selected_ship.removeComponent(i);
                inRange[temp]++;
                //current.component_storage[temp]++;
            }
        }

        if(tmp)
            selected_ship.installComponent(toInstall,i);                                    //Update ship w/ component
    }
}
