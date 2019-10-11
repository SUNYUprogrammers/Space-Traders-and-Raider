using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Class : Ship_Class
{
    private new void Start()
    {
        base.Start();
        power = 2;
        ship_type = "Destroyer";
        size = 10;
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }
}