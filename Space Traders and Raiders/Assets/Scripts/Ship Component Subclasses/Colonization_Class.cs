﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Colonization_Class : Component_Class
{
    // Start is called before the first frame update
    public override void Awake()
    {
        type = "Colonization";
    }

    // Update is called once per frame
    void Update()
    {
        if (img == null)
        {
            img = ((GameObject)Resources.Load("Colonization")).GetComponent<Image>().sprite;
            //img = Resources.Load("Victory") as Sprite;
            print("HEY YOU " + img);
        }
    }
}
