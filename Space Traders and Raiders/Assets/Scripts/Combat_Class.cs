using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Ship in stack[0] is ship that initated combat
 0 == current player, 1 == ememy player
     */
public class Combat_Class : MonoBehaviour
{
    public void Combat(Ship_Class[] shipStack)
    {
        int placeinstack = -1;
        foreach(Ship_Class i in shipStack)//ignore
        {
            if (i != null)
            {
                print("Ship " + i.name);//Name of ship overlapped
                i.shipsInStack = shipStack;
                placeinstack++;
            }
            print(placeinstack);
            if(placeinstack == 1)
            {
                //GameObject.Destroy(shipStack[placeinstack].gameObject);
                print("object destroyed");
            }
        }
       // print("combat");
    }
}
