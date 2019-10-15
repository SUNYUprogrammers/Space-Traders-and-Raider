using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cruiser_Class : Ship_Class
{
    private new void Start()
    {
        base.Start();
        power = 3;
        ship_type = "Cruiser";
        size = 15;
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }
}