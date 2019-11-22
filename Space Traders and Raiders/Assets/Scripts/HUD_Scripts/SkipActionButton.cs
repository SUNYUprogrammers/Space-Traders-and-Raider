using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkipActionButton : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        ShipInfo shipInfo = GameObject.FindObjectOfType<ShipInfo>();
        shipInfo.clearDisplay();
    }
}
