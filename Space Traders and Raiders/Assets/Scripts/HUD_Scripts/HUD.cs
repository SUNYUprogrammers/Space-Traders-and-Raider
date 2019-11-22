using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class HUD : MonoBehaviour
{

    public static List<RaycastResult> raycastResults;
    [SerializeField] private Text victoryPointsText;
    [SerializeField] private Text wealthText;
    [SerializeField] private Text achievementText;
    [SerializeField] private Text powerText;
    [SerializeField] private Text commonMineralText;
    [SerializeField] private Text uncommonMineralText;
    [SerializeField] private Text rareMineralText;

    //[SerializeField] private Text turnNumber;
    [SerializeField] private ShipInfo shipInfo;
    [SerializeField] private NotificationsDisplay notifications;



    void Update()
    {
        raycastResults = GetEventSystemRaycastResults();
        //checkForHUDHoverOver();
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

    public void updateHUD() {

        GameManager manager = FindObjectOfType<GameManager>();
        Player_Class player = manager.currentPlayer;
        victoryPointsText.text = player.calcVictoryPoints().ToString();
        wealthText.text = player.getWealth().ToString();
        achievementText.text = player.getAchievement().ToString();
        commonMineralText.text = player.getCommonMineral().ToString();
        uncommonMineralText.text = player.getRareMineral().ToString();
        rareMineralText.text = player.getVeryRareMineral().ToString();
        //turnNumber.text = manager.turnsSoFar.ToString();
        
        clearShipInfo();
        notifications.refreshNotificationsDisplay(player);

    }

    public void updateShipInfo(Ship_Class ship, int colorIndex) {
        shipInfo.updateDisplay(ship, colorIndex);
    }

    public void clearShipInfo() {
        shipInfo.clearDisplay();
    }

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

    public void addNotificationForPlayer(Player_Class player, string notification) {
        notifications.addNotificationForPlayer(player, notification);
    }

    public void addNotificationForActivePlayer(string notification) {
        GameManager manager = FindObjectOfType<GameManager>();
        Player_Class player = manager.currentPlayer;
        notifications.addNotificationForPlayer(player, notification);
        notifications.refreshNotificationsDisplay(player);
    }

    public void clearNotifcationsForCurrentPlayer() {
        GameManager manager = FindObjectOfType<GameManager>();
        Player_Class player = manager.currentPlayer;
        notifications.clearNotificationsForPlayer(player);
        notifications.refreshNotificationsDisplay(player);
    }


    ///Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }

    public ShipInfo getShipInfoDisplay() {
        return shipInfo;
    }

}
