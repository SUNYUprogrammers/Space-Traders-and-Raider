using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    StarSystem[] systems;

    // Start is called before the first frame update
    void Start()
    {
        systems = new StarSystem[Random.Range(4,4)];
        for(int i = 0; i < systems.Length; i++)
        {
            systems[i] = new StarSystem();

            for (int j = 0; j < i; j++)
            {
                while (systems[i].getPosition() == systems[j].getPosition())
                {
                    systems[i].setPosition(Random.Range(0, 3), Random.Range(0, 3));
                }
            }
        }

        for(int i = 0; i < systems.Length; i++)
        {
            Debug.Log(systems[i].getPosition());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
