using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEntry : MonoBehaviour
{
    public float xOpen;
    public float xClosed;
    public bool opening = false;
    public bool open = false;
    public float expansionRate;

    void Update()
    {
        if(opening && !open) {
            if(transform.position.x < xOpen) {
                transform.position += new Vector3(expansionRate, 0, 0);
            } else {
                transform.position = new Vector3(xOpen, transform.position.y, transform.position.z);
                open = true;
            }
        } else if(!opening){ //opening == false
            if(transform.position.x > xClosed) {
                transform.position -= new Vector3(expansionRate, 0, 0);
            }
        }
    }
}
