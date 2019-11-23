using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LayoutButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.FindObjectOfType<InstallMenu>().gameObject.GetComponent<Canvas>().enabled = 
            !GameObject.FindObjectOfType<InstallMenu>().gameObject.GetComponent<Canvas>().enabled; ;
        //throw new System.NotImplementedException();
    }
}
