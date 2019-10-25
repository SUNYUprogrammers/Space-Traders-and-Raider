using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool stackerRunning;

    [SerializeField] HUD hud;

    public int turnsSoFar = 0;
    public Player_Class[] players;
    public Player_Class currentPlayer;

    public StarSystem[] systems = new StarSystem[0];

    //[SerializeField]
    static int[,] cost1 = new int[5, 5];
    static int[,] cost2 = new int[5, 5];
    static int[,] cost3 = new int[5, 5];

    // Start is called before the first frame update
    void Awake()
    {
        players[0] = this.gameObject.AddComponent<Player_Class>();
        players[0].playerFaction = "Player1";
        players[1] = this.gameObject.AddComponent<Player_Class>();
        players[1].playerFaction = "Player2";

        currentPlayer = players[0];
        players[0].currentTurn = true;

        cost1[0, 0] = 150;               //[-,X] X is facility type, - is upgrade level. Upgrade 0 is initial build cost
        cost1[0, 1] = 150;               //Organized MINE, SHIPYARD, SDS, BARRACKS, TC
        cost1[0, 2] = 30;
        cost1[0, 3] = 30;
        cost1[0, 4] = 30;

        cost1[1, 0] = 70;
        cost1[1, 1] = 100;
        cost1[1, 2] = 0;
        cost1[1, 3] = 0;
        cost1[1, 4] = 20;

        cost1[2, 0] = 100;
        cost1[2, 1] = 170;
        cost1[2, 2] = 0;
        cost1[2, 3] = 0;
        cost1[2, 4] = 40;

        cost1[3, 0] = 120;
        cost1[3, 1] = 220;
        cost1[3, 2] = 0;
        cost1[3, 3] = 0;
        cost1[3, 4] = 80;

        cost1[4, 0] = 150;
        cost1[4, 1] = 300;
        cost1[4, 2] = 0;
        cost1[4, 3] = 0;
        cost1[4, 4] = 150;

        cost2[0, 0] = 20;               //[-,X] X is facility type, - is upgrade level. Upgrade 0 is initial build cost
        cost2[0, 1] = 50;               //Organized MINE, SHIPYARD, SDS, BARRACKS, TC
        cost2[0, 2] = 10;
        cost2[0, 3] = 10;
        cost2[0, 4] = 30;

        cost2[1, 0] = 20;
        cost2[1, 1] = 30;
        cost2[1, 2] = 0;
        cost2[1, 3] = 0;
        cost2[1, 4] = 20;

        cost2[2, 0] = 50;
        cost2[2, 1] = 60;
        cost2[2, 2] = 0;
        cost2[2, 3] = 0;
        cost2[2, 4] = 40;

        cost2[3, 0] = 80;
        cost2[3, 1] = 90;
        cost2[3, 2] = 0;
        cost2[3, 3] = 0;
        cost2[3, 4] = 80;

        cost2[4, 0] = 100;
        cost2[4, 1] = 120;
        cost2[4, 2] = 0;
        cost2[4, 3] = 0;
        cost2[4, 4] = 150;

        cost3[0, 0] = 10;               //[-,X] X is facility type, - is upgrade level. Upgrade 0 is initial build cost
        cost3[0, 1] = 20;               //Organized MINE, SHIPYARD, SDS, BARRACKS, TC
        cost3[0, 2] = 0;
        cost3[0, 3] = 0;
        cost3[0, 4] = 30;

        cost3[1, 0] = 10;
        cost3[1, 1] = 10;
        cost3[1, 2] = 0;
        cost3[1, 3] = 0;
        cost3[1, 4] = 20;

        cost3[2, 0] = 30;
        cost3[2, 1] = 30;
        cost3[2, 2] = 0;
        cost3[2, 3] = 0;
        cost3[2, 4] = 40;

        cost3[3, 0] = 50;
        cost3[3, 1] = 60;
        cost3[3, 2] = 0;
        cost3[3, 3] = 0;
        cost3[3, 4] = 80;

        cost3[4, 0] = 80;
        cost3[4, 1] = 90;
        cost3[4, 2] = 0;
        cost3[4, 3] = 0;
        cost3[4, 4] = 120;
        //Debug.Break();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))                                                                //Detect player click
        {
            //print("Click " + Input.GetKey(KeyCode.LeftControl) + Input.GetKey(KeyCode.LeftShift));
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

        foreach (Ship_Class i in temp)//put ships into an array
        {
            if (pos == i.pos)
            {
                shipStack[j] = i;
               //print("Overlap "+shipStack[j].name);//what ship is overlapped
                j++;
            }
        }
        foreach(Ship_Class i in shipStack)//ignore
        {
            if (i != null)
            {
                //print("Ship " + i.name);//Name of ship overlapped
                i.shipsInStack = shipStack;
            }
        }
        if (true)
        {
            Combat_Class name = GameObject.FindObjectOfType<Combat_Class>();
            name.Combat(shipStack);
        }

        stackerRunning = false;
    }
    public void endTurn()
    {
        print(currentPlayer.playerFaction);

        bool movesLeft = false;
        foreach (Ship_Class temp in currentPlayer.playerShips)
        {
            if (temp != null)
            {
                if (temp.moves_left > 0)
                {
                    movesLeft = true;
                }
                temp.newTurn();
                temp.selected = false;
            }
        }
        print(movesLeft);
        if (movesLeft == false || GameObject.Find("confirm").GetComponent<Canvas>().enabled == true)
        {
            players[0].currentTurn = !players[0].currentTurn;
            players[1].currentTurn = !players[1].currentTurn;
            foreach (Player_Class temp in players)
            {
                temp.winCon();
                if (temp.currentTurn)
                {
                    currentPlayer = temp;
                    this.scanSystems();
                    hud.updateHUD();
                }
            }
            turnsSoFar++;

            GameObject.Find("Next Turn").GetComponent<Canvas>().enabled = true;
            GameObject.Find("confirm").GetComponent<Canvas>().enabled = false;
        }
        else
        {
            GameObject.Find("confirm").GetComponent<Canvas>().enabled=true;
        }
        
    }

    private void scanSystems()
    {
        foreach(StarSystem sys in systems)
        {
            sys.turnStart();
        }
    }

    public void registerSystem(StarSystem theSys)
    {
        StarSystem[] temp = new StarSystem[systems.Length + 1];
        systems.CopyTo(temp, 0);
        systems = temp;
        systems[systems.Length - 1] = theSys;
    }

    public StarSystem getVacantSystem()
    {
        int id = Random.Range(0, systems.Length);
        while (systems[id].owner != null)
        {
            id = Random.Range(0, systems.Length);
        }

        return systems[id];
    }

    public void calcResources(int upgrade_lvl, int type, Player_Class owner)
    {
        owner.chargeResources(cost1[upgrade_lvl,type], cost2[upgrade_lvl, type], cost3[upgrade_lvl, type]);
    }
}

