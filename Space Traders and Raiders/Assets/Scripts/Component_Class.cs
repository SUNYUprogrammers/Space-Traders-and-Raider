using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Component_Class : MonoBehaviour
{
    [SerializeField]
    protected string type;
    [SerializeField]
    protected string faction;
    [SerializeField]
    public Sprite img;

    public int health = 1;

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
      if(img == null){
        img = ((GameObject)Resources.Load("Victory")).GetComponent<Image>().sprite;
        print("HEY YOU " + img);
      }
    }

    public Sprite getSprite(){
      return img;
    }
}
