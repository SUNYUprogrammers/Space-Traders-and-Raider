using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate_Class : Ship_Class
{
    private new void Awake()
    {
        power = 1;
	      ship_type = "Frigate";
        size = 5;
        pos = this.gameObject.transform.position;

        base.Awake();
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }
}
