using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool stackerRunning;

    public Player_Class[] players;
    public Player_Class currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        players[0] = this.gameObject.AddComponent<Player_Class>();
        players[0].playerFaction = "Player1";
        players[1] = this.gameObject.AddComponent<Player_Class>();
        players[1].playerFaction = "Player2";

        currentPlayer = players[0];
        players[0].currentTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))                                                                //Detect player click
        {
            print("Click " + Input.GetKey(KeyCode.LeftControl) + Input.GetKey(KeyCode.LeftShift));
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))                                                         //If selection found
            {
                //print("You selected " + hit.transform.name+" : "+this.transform.name);               //Ensure you picked right object
                if (hit.transform.gameObject.GetComponent<Ship_Class>() != null /*&& hit.transform.name == this.transform.name*/)
                {                                                                                      //If current player owns ship and is only left clicking
                    if (hit.transform.gameObject.GetComponent<Ship_Class>().faction == currentPlayer.playerFaction && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
                    {
                        hit.transform.gameObject.GetComponent<Ship_Class>().selected = !hit.transform.gameObject.GetComponent<Ship_Class>().selected;
                    }                                                                                  //If current player owns ship and is only shift left clicking
                    if (true/*faction == factionCurrent*/ && !Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift))
                    {
                        foreach (Ship_Class i in hit.transform.gameObject.GetComponent<Ship_Class>().shipsInStack)
                        {
                            if (i != null && true/*faction == factionCurrent*/)
                            {
                                print("Cycle through and select " + i.name+" from "+ hit.transform.gameObject.name);

                                if (hit.transform.gameObject.GetComponent<Ship_Class>().selected == true)
                                    i.selected = false;
                                else
                                    i.selected = true;
                            }


                        }
                    }                                                                               //If current player owns ship and is only control left clicking
                    if (hit.transform.gameObject.GetComponent<Ship_Class>().faction == currentPlayer.playerFaction && Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
                    {
                        hit.transform.gameObject.GetComponent<Ship_Class>().selectFromStack++;
                        if (hit.transform.gameObject.GetComponent<Ship_Class>().selectFromStack >= hit.transform.gameObject.GetComponent<Ship_Class>().shipsInStack.Length)
                        {
                            hit.transform.gameObject.GetComponent<Ship_Class>().selectFromStack = 0;
                        }

                        foreach (Ship_Class i in hit.transform.gameObject.GetComponent<Ship_Class>().shipsInStack)
                        {
                            if (true/*faction == factionCurrent*/ && i != null)
                            {
                                print("Ship from stack " + i.name);

                                //print("");

                                if (hit.transform.gameObject.GetComponent<Ship_Class>().shipsInStack[hit.transform.gameObject.GetComponent<Ship_Class>().
                                    selectFromStack] == i)
                                {
                                    print("Selected " + i.name);
                                    i.selected = true;
                                }
                                else
                                    i.selected = false;
                            }
                        }
                    }                                                                            //If current player owns ship and is alt left clicking
                    if (true/*faction == factionCurrent*/ && Input.GetKey(KeyCode.LeftAlt))
                    {
                        foreach (Ship_Class i in hit.transform.gameObject.GetComponent<Ship_Class>().shipsInStack)
                        {
                            if (i != null)
                            {
                                i.selected = false;
                            }
                        }
                    }

                }
            }
        }
    }

    public void ShipStacker(Vector3 pos)
    {
        stackerRunning = true;

        Ship_Class[] temp = GameObject.FindObjectsOfType<Ship_Class>();

        int j = 0;                                                              //Number of ships in that location
        Ship_Class[] shipStack = new Ship_Class[temp.Length];                   //Ships in stack

        foreach (Ship_Class i in temp)
        {
            if (pos == i.pos)
            {
                shipStack[j] = i;
                print("Overlap "+shipStack[j].name);
                j++;
            }
        }
        foreach(Ship_Class i in shipStack)
        {
            if (i != null)
            {
                print("Ship " + i.name);
                i.shipsInStack = shipStack;
            }
        }

        stackerRunning = false;
    }
    public void endTurn()
    {
        players[0].currentTurn = !players[0].currentTurn;
        players[1].currentTurn = !players[1].currentTurn;
    }

}

