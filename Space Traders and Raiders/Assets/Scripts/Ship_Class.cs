using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ship_Class : MonoBehaviour
{
    [SerializeField]
    protected string ship_type;                 //What class of ship it is
    [SerializeField]
    public bool selected;
    [SerializeField]
    public string faction;

    public int power;

    protected int size;                         //How many slots the ship has
    [SerializeField]
    public Component_Class[] parts_list;     //What component is in each slot
    [SerializeField]
    protected int ship_speed;                   //How fast can the ship move, calculated from stored thrusters
    [SerializeField]
    protected GameObject rangeIndicator;        //How far the ship can move, represented visually
    [SerializeField]
    public int moves_left;                   //How many more squares the ship can move
    protected int[] storage;                    //What resources is the ship carrying, might take up a slot so may become component?
    [SerializeField]
    public Vector3 pos;                      //Where is the ship on the grid
    [SerializeField]
    public SpriteRenderer hostile;              //Marker for other players to identify you as hostile

    protected int beamDamage;                   //Combat statistics
    protected int missileDamage;
    protected int marineComplement;

    public GameManager gm;

    public Ship_Class[] shipsInStack;
    public int selectFromStack = 0;
    public string[] trade = new string[2];
    public SpriteRenderer ship;
    public void Awake()
    {
        //print("Ship_Class Start function");

        //ship_speed = 4;                         /*TEMPORARY*/

        gm = GameObject.FindObjectOfType<GameManager>();

        hostile.enabled = false;

        parts_list = new Component_Class[size];     //Set component list size to the amount of slots it has

        print(parts_list.Length + ", " + size);
        ship_speed = 0;
        foreach (Component_Class i in parts_list)    //Calculate ship speed by adding all thruster component values together
        {
            if (i != null)
            {
                print(i.getType());
                if (i.getType() == "Thruster")
                    ship_speed = +1;
                if (i.getType() == "Beam")
                    beamDamage = +1;
                if (i.getType() == "Missile")
                    missileDamage = +1;
            }
        }
        moves_left = ship_speed;

    }

    public void Update()
    {
        if (selected)
        {
            rangeIndicator.SetActive(true);
            rangeIndicator.transform.localScale = new Vector3(3f * (float)moves_left, 3f * (float)moves_left, 1);
            hostile.enabled = false;
        }
        else
            rangeIndicator.SetActive(false);



        if (Input.GetMouseButtonDown(1) && selected)                                                                        //Detect player click
        {
            //print("Click Move");
            Vector3 pos_temp = pos;
            Vector3 temp = Input.mousePosition;
            temp.z = 10f;
            temp = Camera.main.ScreenToWorldPoint(temp);                                                                    //Find coord to move to

            print("Move ship to: " + temp.x + " " + temp.y);
            pos_temp.x = temp.x - pos_temp.x;
            pos_temp.y = temp.y - pos_temp.y;
            //print("Move ship in direction: " + (int)pos_temp.x + " " + (int)pos_temp.y);
            pos_temp.x = Mathf.RoundToInt(pos_temp.x);
            pos_temp.y = Mathf.RoundToInt(pos_temp.y);
            MoveShipTo((int)pos_temp.x, (int)pos_temp.y);

            gm.checkTrade();
        }

        if (selected)
        {
            MoveShipDirection();
        }

    }

    public void newTurn()
    {
        moves_left = ship_speed;
        print("New Turn " + moves_left + " " + ship_speed);
    }

    public string getShipType()
    {
        return ship_type;
    }

    public void MoveShipTo(int x, int y)                                            //Move ship to relative coords
    {
        int temp_move = moves_left;

        if (x != 0 || y != 0)                                                       //If a move is being attempted, calculate if movement is possible
        {
            float x_temp = x;
            float y_temp = y;

            print(x + " " + y);

            while (x_temp != 0 && y_temp != 0)                                      //While ship is moving diagonal
            {
                //Move diagonal
                if (x_temp > 0)
                {
                    x_temp--;
                    if (y_temp > 0)
                        y_temp--;
                    else
                        y_temp++;
                }
                else
                {
                    x_temp++;
                    if (y_temp > 0)
                        y_temp--;
                    else
                        y_temp++;
                }
                //print("Diagonal " + moves_left);
                moves_left--;
                //print("Diagonal after " + moves_left);
            }
            if (x_temp != 0)
            {
                //print(moves_left + " " + x_temp);
                moves_left = moves_left - Mathf.Abs((int)x_temp);
                //print(moves_left);
            }
            if (y_temp != 0)
            {
                //print(moves_left + " " + y_temp);
                moves_left = moves_left - Mathf.Abs((int)y_temp);
                //print(moves_left);
            }

            if (moves_left < 0)
            {
                print("Not enough moves left");
            }
        }

        print("Moves left " + moves_left);

        if (moves_left >= 0)
        {
            Vector3 temp = pos;
            if (true)
            //if ((Mathf.Abs(x) + Mathf.Abs(y) <= ship_speed))                  //Find if position is within move range and determine move type (bool), now void
            {
                if (gm.x_min > pos.x + x || pos.x + x > gm.x_max)                     //Set to loop on reaching world border, if that's what designers decide
                {                                                               //Does not work for righ click movements
                    print("Out of area");
                    if (pos.x + x < gm.x_min)
                    {
                        x = -gm.x_min + gm.x_max;
                    }
                    if (pos.x + x > gm.x_max)
                    {
                        x = -gm.x_max + gm.x_min;
                    }
                }
                if (gm.y_min > pos.y + y || pos.y + y > gm.y_max)
                {
                    print("Out of area");
                    if (pos.y + y < gm.y_min)
                    {
                        y = -gm.y_min + gm.y_max;
                    }
                    if (pos.y + y > gm.y_max)
                    {
                        y = -gm.y_max + gm.y_min;
                    }
                }

                temp = new Vector3(pos.x + x, pos.y + y, 0);
            }

            /*if((Mathf.Abs(pos.x - x) + Mathf.Abs(pos.y - y) <= ship_speed) && exact)  //Find if position is within move range and determine move type
            {
                 temp = new Vector3(x, y, 0);
            }*/

            //print("Temp "+temp);
            if (temp == pos)
            {
                print("Move Cancelled");
                moves_left = temp_move;
            }

            pos = temp;
            gameObject.transform.position = pos;                                        //Set new position
            gm.checkTrade();
        }
        else
        {
            print("Move cancelled");
            moves_left = temp_move;
        }

        if (moves_left == 0)
        {
            selected = false;
        }
    }

    public void MoveShipDirection()
    {
        //print("Move Ship");

        if (Input.GetButtonDown("Move Up"))
        {
            print("Move Ship Up");
            MoveShipTo(0, 1);
            //moves_left--;
        }
        if (Input.GetButtonDown("Move Left"))
        {
            print("Move Ship Left");
            MoveShipTo(-1, 0);
            //moves_left--;
        }
        if (Input.GetButtonDown("Move Right"))
        {
            print("Move Ship Right");
            MoveShipTo(1, 0);
            //moves_left--;
        }
        if (Input.GetButtonDown("Move Down"))
        {
            print("Move Ship Down");
            MoveShipTo(0, -1);
            //moves_left--;
        }

        if (Input.GetButtonDown("Move LUp"))
        {
            print("Move Ship LUp");
            MoveShipTo(-1, 1);
            //moves_left--;
        }
        if (Input.GetButtonDown("Move LDown"))
        {
            print("Move Ship Left");
            MoveShipTo(-1, -1);
            //moves_left--;
        }
        if (Input.GetButtonDown("Move RUp"))
        {
            print("Move Ship Right");
            MoveShipTo(1, 1);
            //moves_left--;
        }
        if (Input.GetButtonDown("Move RDown"))
        {
            print("Move Ship Down");
            MoveShipTo(1, -1);
            //moves_left--;
        }

    }

    public void storeItem(int i, int j)                                             //Store resources by location in array, and amount
    {
        storage[i] = +j;                                                            //Add [j] of item type [i] to storage
    }

    public void removeItem(int i, int j)                                            //Store resources by location in array, and amount
    {
        if ((storage[i] != 0) && (storage[i] >= j))                                //Check if storage is empty and that there are enough resources to pull
            storage[i] = -j;                                                        //Add [j] of item type [i] to storage
    }

    public void boardMarines(int i)                                                 //Store resources by location in array, and amount
    {
        marineComplement = +i;                                                      //Add [j] of item type [i] to storage
    }

    public void disembarkMarines(int i)                                             //Store resources by location in array, and amount
    {
        if ((marineComplement != 0) && (marineComplement >= i))                     //Check if storage is empty and that there are enough resources to pull
            marineComplement = -i;                                                  //Add [j] of item type [i] to storage
    }

    public void installComponent(Component_Class i, int j)
    {
        print(i);
        i.setFaction(this.faction);

        if (i.getType() == "")
        {
            i.Awake();
        }

        if (true)                                                   //If at drydock, and part exists, etc.
        {
            //print(i.getType()+" "+j);
            parts_list[j] = i;
            print("Component installed " + parts_list[j].getType());
            if (i.getType() == "Thruster")
            {
                //parts_list = new Component_Class[size];             //Set component list size to the amount of slots it has
                ship_speed = 0;
                foreach (Component_Class k in parts_list)           //Recalculate ship speed by adding all thruster component tiers together
                {
                    if (k != null)
                    {
                        if (k.getType() == "Thruster")
                        {
                            print(ship_speed+" +1 speed");
                            ship_speed++;
                        }
                    }
                }
                print("New Speed: "+ship_speed);
            }
        }
    }
    //test
    public Component_Class removeComponent(int i)
    {
        Component_Class temp = parts_list[i];
        parts_list[i] = null;
        return temp;
    }

    public void OnTriggerEnter(Collider other)
    {
        //print(other.name);s
        if (other.GetComponent<Ship_Class>() != null && this.faction == GameObject.FindObjectOfType<GameManager>().currentPlayer.playerFaction)
        {
            print("Ships overlapping");
            GameObject.FindObjectOfType<GameManager>().ShipStacker(pos);
            print("Ships in Ship class " + shipsInStack.Length);
            BeginCombat();
        }
    }

       
    public void BeginCombat()
    {
         Combat_Class name = GameObject.FindObjectOfType<Combat_Class>();
         name.askCombat(shipsInStack,shipsInStack.Length);
    }
}

