using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeRange_Detect : MonoBehaviour
{
    [SerializeField]
    public string faction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        //print(other.name);
        if(other.GetComponent<TradeRange_Detect>() != null)
        {
            //print("In Range: "+this.faction+" "+other.GetComponent<TradeRange_Detect>().faction);
            foreach(Player_Class i in GameObject.FindObjectOfType<GameManager>().players)
            {
                if(i.playerFaction == other.GetComponent<TradeRange_Detect>().faction)
                {
                    i.trade[0] = this.faction;
                }
            }
        }
    }
}
