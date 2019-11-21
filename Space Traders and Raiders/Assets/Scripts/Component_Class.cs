using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Component_Class : MonoBehaviour
{
    [SerializeField]
    protected string type;
    [SerializeField]
    protected string faction;
    [SerializeField]
    

    //[SerializeField]
    //protected int tier;
    public string getType()
    {
        //print("Returning "+type);
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

    /*public int getTier()
    {
        return tier;
    }

    public void setTier(int i)
    {
        tier = i;
    //}*/

    // Start is called before the first frame update
    abstract public void Awake();
    //{
      //  type = "Null";
    //}

    // Update is called once per frame
    void Update()
    {
            
    }
}
