using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuEntry : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public float xOpen;
    public float xClosed;
    public bool opening = false;
    public bool open = false;
    public float expansionRate;
    public Ship_Class ship;



    void Update()
    {
        handleOpenAndClose();

    }

    private void handleOpenAndClose() {
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!open) return;
        ship.selected = !ship.selected;

        GameManager manager = GameObject.FindObjectOfType<GameManager>();

        if(ship.selected) {
            GameObject.FindObjectOfType<HUD>().getShipInfoDisplay().updateDisplay(ship, manager.getFactionIndex(ship.faction));
        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!open) return;
        //ship.highlighted = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //TODO remove ship highlight
        //ship.highlighted = false;
    }
}
