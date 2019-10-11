using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector
{
    StarSystem[] systems;

    // Start is called before the first frame update
    public Sector()
    {
        //determine how many systems are going to be present
        int numSystems = Random.Range(0, 100);
        if(numSystems <= (int)MapGenerator.SystemCount.TWOSYS)
        {
            numSystems = 2;
        }
        else if (numSystems <= (int)MapGenerator.SystemCount.THREESYS)
        {
            numSystems = 3;
        }
        else if (numSystems <= (int)MapGenerator.SystemCount.ONESYS)
        {
            numSystems = 1;
        }

        systems = new StarSystem[numSystems];

        for (int i = 0; i < systems.Length; i++)
        {
            systems[i] = new StarSystem();
            bool noConflict = false;

            //Normally would use !noConflict, but that got confusing
            while (noConflict == false)
            {
                //check if there's a conflict
                noConflict = true;
                for (int j = 0; j < i && noConflict; j++)
                {
                    noConflict = !(systems[i].getPosition() == systems[j].getPosition());
                }

                if (!noConflict)
                {
                    systems[i].setPosition(Random.Range(0, 4), Random.Range(0, 4));
                }
            }
        }
    }

    public StarSystem[] getSystems()
    {
        return this.systems;
    }
}
