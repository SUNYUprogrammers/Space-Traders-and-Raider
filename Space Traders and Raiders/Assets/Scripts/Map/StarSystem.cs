using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem 
{
    public Player_Class owner;
    GameManager gm;
    protected Facilities_Class[] facilities = new Facilities_Class[5];

    public GameObject tile;

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

    public void buildFacility(Facilities_Class i, bool cost)
    {
        //print("Building " + i.getTypeString());

        i.faction = this.owner.playerFaction;
        i.self = new Color(this.owner.PlayerColor.r, this.owner.PlayerColor.g, this.owner.PlayerColor.b,.5f);

        if (facilities[i.getType()] == null)
            facilities[i.getType()] = i;
        else
        {
            int temp;
            temp = facilities[i.getType()].getTier();
            facilities[i.getType()].setTier(temp++);
        }

        if (cost)
        {
            gm.calcResources(i.getTier(),i.getType(),owner);
        }
    }
}
