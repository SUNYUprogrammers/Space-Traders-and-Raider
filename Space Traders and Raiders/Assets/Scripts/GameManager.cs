using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool stackerRunning;

    public GameObject planetUI;
    [SerializeField] HUD hud;

    public int turnsSoFar = 0;

    public string[] factions;

    public Sprite[] homeSystems;
    public Sprite[] tradeRadius;

    public Player_Class[] players;
    public Player_Class currentPlayer;

    public StarSystem[] systems = new StarSystem[0];

    //[SerializeField]
    static int[,] cost1 = new int[5, 5];
    static int[,] cost2 = new int[5, 5];
    static int[,] cost3 = new int[5, 5];

    public int x_max;                        //World border, detect when to transition when the designers figure out what to do for that
    public int y_max;
    public int x_min;
    public int y_min;

    private TurnRenderController[] tRenCons = new TurnRenderController[0];

    // Start is called before the first frame update
    void Awake()
    {
        x_max = 3;                              //Need to link to map generator
        x_min = -4;

        y_max = 4;
        y_min = -3;

        players = new Player_Class[factions.Length];
        for(int i = 0; i < players.Length; i ++){
          players[i] = this.gameObject.AddComponent<Player_Class>();
          players[i].playerFaction = factions[i];
        }

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
        if (Input.GetMouseButtonDown(0) && !this.planetUI.activeSelf)                                                                //Detect player click
        {
            //print("Click " + Input.GetKey(KeyCode.LeftControl) + Input.GetKey(KeyCode.LeftShift));
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitSomething = false;
            int layerMask = 1 << 8; //Ships
            if (Physics.Raycast(ray, out hit, layerMask))                                                         //If selection found
            {
                //print("You selected " + hit.transform.name+" : "+this.transform.name);               //Ensure you picked right object
                //The object hit is a Ship
                if (hit.transform.gameObject.GetComponent<Ship_Class>() != null) //&& hit.transform.name == this.transform.name)
                {                                                //If current player owns ship and is only left clicking
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
                    hitSomething = true;
                }
            }
            layerMask = layerMask << 1; //next layer is systems
            if(!hitSomething && Physics.Raycast(ray, out hit, layerMask)){
              hitSomething = true;
              if (hit.transform.gameObject.GetComponent<SelectableSystem>() != null){
                SelectableSystem ss = hit.transform.gameObject.GetComponent<SelectableSystem>() as SelectableSystem;
                for(int i = 0; i < systems.Length; i ++){
                  if((systems[i].tile.GetComponent<SelectableSystem>() as SelectableSystem) != (ss)){
                    (systems[i].tile.GetComponent<SelectableSystem>() as SelectableSystem).deselect();
                  }
                }
                if(ss.isSelectable()){
                  if(ss.isSelected()){
                    ss.deselect();
                  } else {
                    ss.select();
                  }
                }

              }
            }
        } else if(Input.GetMouseButtonDown(0)){  //The planetUI is up

        }
        if(false)
        {
            //checkTrade();
        }
    }

    public void checkTrade()
    {
        TradeCenter_Class[] temp = GameObject.FindObjectsOfType<TradeCenter_Class>();
        Ship_Class[] temp2 = GameObject.FindObjectsOfType<Ship_Class>();
        int j, l, m;

        foreach (Ship_Class k in temp2)
        {
            m = 0;
            foreach (TradeCenter_Class i in temp)
            {
                for (j = 0; i.x != null && j < i.x.Length; j++)
                {
                    for (l = 0; l < i.y.Length; l++)
                    {
                        if ((k.pos.x == i.x[j] && k.pos.y == i.y[l]) && k.faction != i.faction)
                        {
                            k.trade[m] = i.faction;
                            m++;
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

        stackerRunning = false;
    }

    public void endTurn()
    {
        print(tRenCons);

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
                    Debug.Log(hud);
                    hud.updateHUD();
                    updateTurnRenderControllers();
                    Debug.Log(this);
                    this.scanSystems();
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

    private void updateTurnRenderControllers(){
      for(int i = 0; i < tRenCons.Length; i ++){
        tRenCons[i].endTurn();
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

    public void registerTurnRenderController(TurnRenderController theCon){
      print("Registering " + theCon);
      TurnRenderController[] temp = new TurnRenderController[tRenCons.Length +1];
      tRenCons.CopyTo(temp, 0);
      tRenCons = temp;
      tRenCons[tRenCons.Length -1] = theCon;
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

    public int getFactionIndex(string faction){
      int ret = -1;

      for(int i = 0; i < factions.Length && ret < 0; i ++){
        if(faction.Equals(factions[i])){
          ret = i;
        }
      }

      return ret;
    }
}
