using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleship_Class : Ship_Class
{
    private new void Awake()
    {
        power = 4;
        ship_type = "Battleship";
        size = 20;
        pos = this.gameObject.transform.position;

        base.Awake();
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }
}