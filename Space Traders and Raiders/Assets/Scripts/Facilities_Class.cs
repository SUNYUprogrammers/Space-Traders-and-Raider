using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Facilities_Class : MonoBehaviour
{
    public int type;
    public string faction;
    [SerializeField]
    protected int tier;

    public Transform tile;
    public Color self;

    // Start is called before the first frame update
    public void Start()
    {
        tile = this.gameObject.transform;
    }

    // Update is called once per frame
    public void Update()
    {

    }
    abstract public string getTypeString();
    public int getType()                     //0 for mine, 1 for shipyard, 2 for SDS, 3 for Barracks, 4 for TC
    {
        //print("TYPE GOTTEN IS " + type);
        return type;
    }
    public string getFaction()
    {
        return faction;
    }
    public void setFaction(string i)
    {
        faction = i;
    }
    public void setTier(int i)
    {
        print("Increasing tier from " + tier + " to " + i);
        tier = i;
    }
    public int getTier()
    {
        //print("Current tier is " + tier);
        return tier;
    }

}
