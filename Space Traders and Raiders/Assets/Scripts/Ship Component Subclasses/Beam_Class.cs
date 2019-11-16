using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_Class : Component_Class
{
    // Start is called before the first frame update
    public override void Awake()
    {
        type = "Beam";
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
