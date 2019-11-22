using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipyard_Class : Facilities_Class
{
    public int[] component_storage = {1,0,1,0,1,1,1,0};
    // Start is called before the first frame update
    new public void Start()
    {
        type = 1;
        tier = 1;
    }

    // Update is called once per frame
    new public void Update()
    {

    }

    override public string getTypeString()
    {
        return "Shipyard";
    }
}
