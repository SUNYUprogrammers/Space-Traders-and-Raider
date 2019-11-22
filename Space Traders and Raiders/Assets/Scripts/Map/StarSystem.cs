using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem 
{
    public Player_Class owner;
    GameManager gm;
    protected Facilities_Class[] facilities = new Facilities_Class[5];
    public GameObject tile;
    public SelectableSystem sel;
    private Vector2Int position = Vector2Int.zero;

    //Stores the type (color)
    private MapGenerator.SystemType type;



    // Start is called before the first frame update
    public StarSystem()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        gm.registerSystem(this);

        //determines the system type based on probabilites.
        int prob = Random.Range(0, 100);
        if(prob <= (int)MapGenerator.SystemType.YELLOW)
        {
            this.type = MapGenerator.SystemType.YELLOW;
        } else if (prob <= (int)MapGenerator.SystemType.GREEN)
        {
            this.type = MapGenerator.SystemType.GREEN;
        } else if (prob <= (int)MapGenerator.SystemType.BLUE)
        {
            this.type = MapGenerator.SystemType.BLUE;
        } else if (prob <= (int)MapGenerator.SystemType.RED)
        {
            this.type = MapGenerator.SystemType.RED;
        }

        /*foreach(Facilities_Class i in facilities)
        {
            //facilities[i] = null;
            Debug.Log("WHAT EVEN ARE THESE!!! "+i.getType());
        }*/
    }

    public Transform getTransform()
    {
        return tile.transform;
    }

    public bool setPosition(int x, int y)
    {
        bool hasSet = false;
        if(x >= 0 && y >= 0)
        {
            position.Set(x, y);
            hasSet = true;
        }

        return hasSet;
    }

    public bool setPosition(Vector2Int v)
    {
        bool hasSet = false;
        if (v.x >= 0 && v.y >= 0)
        {
            position.Set(v.x, v.y);
            hasSet = true;
        }

        return hasSet;
    }

    public Vector2Int getPosition()
    {
        return this.position;
    }

    public MapGenerator.SystemType getType()
    {
        return this.type;
    }

    public void turnStart()
    {
        if(gm.currentPlayer.Equals(this.owner))
        {
            this.owner.setResources(this);
        }
    }

    public StarSystem returnSelf()
    {
        return this;
    }

    /*public void buildFacility(Facilities_Class i, bool cost)
    {
        Debug.Log("Building " + i.getTypeString());

        i.faction = this.owner.playerFaction;
        i.self = new Color(this.owner.PlayerColor.r, this.owner.PlayerColor.g, this.owner.PlayerColor.b, .5f);

        if (facilities[i.getType()] == null)
        {
            Debug.Log("No facility of type found...");
            facilities[i.getType()] = i;
        }
        else
        {
            int temp = 0;
            Debug.Log("Facility Found, Incresing Tier from "+ facilities[i.getType()].getTier()+", temp is "+temp);
            Debug.Log("--GET TYPE-- "+i.getType());
            temp = facilities[i.getType()].getTier();
            temp++;
            facilities[i.getType()].setTier(temp);
            Debug.Log("Facility now at Tier "+facilities[i.getType()].getTier());
        }

        if (cost)
        {
            gm.calcResources(i.getTier(), i.getType(), owner);
        }
    }*/
}
