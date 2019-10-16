using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HUD : MonoBehaviour
{

    public static List<RaycastResult> raycastResults;
    [SerializeField] private Text victoryPoints;
    [SerializeField] private Text achievement;
    [SerializeField] private Text wealth;
    [SerializeField] private Text power;
    [SerializeField] private Text minerals;
    [SerializeField] private Text turnNumber;



    void Update()
    {
        raycastResults = GetEventSystemRaycastResults();
        //Debug.Log(raycastResults);
        //checkForHUDHoverOver();
    }

    void Start() {
        updateHUD();
    }

    public void updateHUD() {
        GameManager gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Player_Class currentPlayer = gm.currentPlayer;
        victoryPoints.text = "" + currentPlayer.calcVictoryPoints();
        wealth.text = "" + currentPlayer.getWealth();
        achievement.text = "" + currentPlayer.getAchievement();
        power.text = "" + currentPlayer.getPower();
        minerals.text = "" + (currentPlayer.getCommonMineral() + currentPlayer.getRareMineral() + currentPlayer.getVeryRareMineral());
        turnNumber.text = "" + 1; //TODO replace 1 with proper method call
    } 

    
    /*public static void checkForHUDHoverOver() {
        raycastResults = GetEventSystemRaycastResults();
        for(int i = 0; i < raycastResults.Count; i++) {
            RaycastResult curResult = raycastResults[i];
            IHUDHoverable hoverable = curResult.gameObject.GetComponent<IHUDHoverable>();
            if(hoverable != null) {
                hoverable.onHover();
            }
        }
    }*/

    public static bool IsPointerOverUIElement(GameObject obj)
    {
        for (int index = 0; index < raycastResults.Count; index++)
        {
            RaycastResult curRaycastResult = raycastResults[index];
            if (curRaycastResult.gameObject == obj) {
                return true;
            }
        }
        return false;
    }
    ///Gets all event system raycast results of current mouse or touch position.
    public List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }
}
