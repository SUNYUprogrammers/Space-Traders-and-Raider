﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thruster_Class : Component_Class
{ 

    // Start is called before the first frame update
    public override void Awake()
    {
        type = "Thruster";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (img == null)
        {
            img = ((GameObject)Resources.Load("Victory")).GetComponent<Image>().sprite;
            //img = Resources.Load("Victory") as Sprite;
            print("HEY YOU " + img);
        }
    }
}
