using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallMenu : MonoBehaviour
{
    public Ship_Class selected_ship;
    public Ship_Class[] ships;

    public int component_type;                  //0 = thrusters, 1 = armour, 2 = beam, 3 = shield, 4 = missile, 5 = colony, 6 = anti, 7 = repair
    public int[] inRange = new int[8];          //Components located in nearby spacedock, position in array referred to as above
    public Component_Class toInstall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setComponent(int i)
    {
        component_type = i;
    }

    public void install(int i)
    {
        switch(component_type)
        {
            case 0:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Thruster_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                }
                break;
            case 1:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Armour_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                }
                break;
            case 2:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Beam_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                }
                break;
            case 3:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Shield_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                }
                break;
            case 4:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Missile_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                }
                break;
            case 5:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Colonization_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                }
                break;
            case 6:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<AntiMissile_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                }
                break;
            case 7:
                if (inRange[component_type] > 0)
                {
                    toInstall = selected_ship.gameObject.AddComponent<Repair_Class>();
                    //Decrement space dock array, currently only decrements self
                    inRange[component_type]--;
                }
                break;
        }
        if(selected_ship.parts_list[component_type] != null)
        {
            int temp = -1;

            selected_ship.parts_list[component_type].getType();
            switch(selected_ship.parts_list[component_type].getType())
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
            if(temp != -1)
                inRange[temp]++;
        }

        selected_ship.installComponent(toInstall,i);
    }
}
