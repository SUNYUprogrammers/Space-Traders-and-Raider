using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationsDisplay : MonoBehaviour
{
    private Dictionary<Player_Class, List<string>> playerToNotificationsMap;
    const int NOTIFICATIONS_LIST_MAX_SIZE = 5;

    [SerializeField] private GameObject notificationPanelPrefab;

    public void Awake()
    {
        playerToNotificationsMap = new Dictionary<Player_Class, List<string>>();
    }
    
    public void addNotificationForPlayer(Player_Class player, string message) {
        createKeyIfNotExists(player);
        List<string> notifications = playerToNotificationsMap[player];
        if(notifications.Count == NOTIFICATIONS_LIST_MAX_SIZE) {
            notifications.RemoveAt(0);
        }
        notifications.Add(message);
        playerToNotificationsMap[player] = notifications;
    }
    
    public void refreshNotificationsDisplay(Player_Class player) {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        createKeyIfNotExists(player);
        foreach(string notification in playerToNotificationsMap[player]) {
            GameObject notificationPanel = Instantiate(notificationPanelPrefab, transform.position, Quaternion.identity);
            notificationPanel.transform.GetChild(0).GetComponent<Text>().text = notification;
            notificationPanel.transform.SetParent(transform, false);
        }

    }

    private void createKeyIfNotExists(Player_Class player) {
        if(!playerToNotificationsMap.ContainsKey(player)) {
            playerToNotificationsMap[player] = new List<string>();
        }
    }

    public void clearNotificationsForPlayer(Player_Class player) {
        createKeyIfNotExists(player);
        List<string> notifications = playerToNotificationsMap[player];
        notifications.Clear();
        playerToNotificationsMap[player] = notifications;
    }
}
