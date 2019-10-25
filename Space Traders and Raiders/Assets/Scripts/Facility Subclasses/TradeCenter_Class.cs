using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeCenter_Class : Facilities_Class
{
    // Start is called before the first frame update
    new public void Start()
    {
        type = 4;
        tier = 1;
    }

    // Update is called once per frame
    new public void Update()
    {
        
    }

    override public string getTypeString()
    {
        return "Trade Center";
    }
}
