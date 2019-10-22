using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : MonoBehaviour 
{
    public Player_Class owner;
    //[SerializeField]
    protected Facilities_Class[] facilities = new Facilities_Class[5];
    GameManager gm;

    public GameObject tile;

    private Vector2Int position = Vector2Int.zero;

    //Stores the type (color)
    [SerializeField]
    private MapGenerator.SystemType type;

    // Start is called before the first frame update

    public void Inst()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        gm.registerSystem(this);

        //determines the system type based on probabilites.
        int prob = Random.Range(0, 100);

       if (prob <= (int)MapGenerator.SystemType.YELLOW)                     
        {
            this.type = MapGenerator.SystemType.YELLOW;
            //print("Yellow 55-84 " +prob);
        } else if (prob <= (int)MapGenerator.SystemType.GREEN)                      //55+30 = 85
        {
            this.type = MapGenerator.SystemType.GREEN;
            //print("Green 85-97 " + prob);
        } else if (prob <= (int)MapGenerator.SystemType.BLUE)                       //85+12 = 97
        {
            this.type = MapGenerator.SystemType.BLUE;
            //print("Blue 97-100 " + prob);
        } else if (prob <= (int)MapGenerator.SystemType.RED)                        //97+3 = 100
        {
            this.type = MapGenerator.SystemType.RED;
            //print("Red 100 " + prob);
        }

        //print("Start function "+this.type+" "+prob);

        switch (type)
        {
            case MapGenerator.SystemType.YELLOW:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindObjectOfType<MapGenerator>().yellowSystem;
                print(this.gameObject.GetComponent<SpriteRenderer>().sprite.name);
                break;

            case MapGenerator.SystemType.GREEN:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindObjectOfType<MapGenerator>().greenSystem;
                break;

            case MapGenerator.SystemType.BLUE:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindObjectOfType<MapGenerator>().blueSystem;
                break;

            case MapGenerator.SystemType.RED:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindObjectOfType<MapGenerator>().redSystem;
                break;

            case MapGenerator.SystemType.EMPTY:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindObjectOfType<MapGenerator>().emptySystem;
                break;
        }

        if (type == MapGenerator.SystemType.EMPTY)
        {
            Destroy(this);
        }
    }

    public Transform getTransform()
    {
        return this.gameObject.transform;
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
        if(gm.currentPlayer.Equals(this.owner) && true)
        {
            this.owner.setResources(this);
        }
    }

    public void buildFacility(Facilities_Class i, bool cost)
    {
        //print("Building " + i.getTypeString());

        if (facilities[i.getType()] == null)
            facilities[i.getType()] = i;
        else
        {
            int temp;
            temp = facilities[i.getType()].getTier();
            facilities[i.getType()].setTier(temp++);
        }

        if(cost)
        {
            //owner.chargeResources();
        }
    }
}
