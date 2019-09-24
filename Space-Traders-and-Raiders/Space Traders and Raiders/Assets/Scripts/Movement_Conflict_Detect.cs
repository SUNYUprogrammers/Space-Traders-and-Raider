using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Conflict_Detect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if(other.GetComponent<Ship_Class>() != null)
        {
            //print(other.name);
            if(other.GetComponent<Ship_Class>().faction != this.gameObject.GetComponentInParent<Ship_Class>().faction)
            {
                //print("Hostile");
                other.GetComponent<Ship_Class>().hostile.enabled = true;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        //print("Trigger Stay");
        if (other.GetComponent<Ship_Class>() != null && !this.GetComponentInParent<Ship_Class>().selected)
        {
            other.GetComponent<Ship_Class>().hostile.enabled = false;
        }
    }

}
