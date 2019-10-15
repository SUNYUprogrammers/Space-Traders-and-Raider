using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnought_Class : Ship_Class
{
    private new void Start()
    {
        base.Start();
        power = 5;
        ship_type = "Dreadnought";
        size = 25;
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }
}