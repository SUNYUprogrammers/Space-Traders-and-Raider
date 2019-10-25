using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDS_Class : Facilities_Class
{
    // Start is called before the first frame update
    new public void Start()
    {
        type = 2;
        tier = 1;
    }

    // Update is called once per frame
    new public void Update()
    {
        
    }

    override public string getTypeString()
    {
        return "Static Defense System";
    }
}
