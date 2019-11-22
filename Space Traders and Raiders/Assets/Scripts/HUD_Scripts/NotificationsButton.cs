using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NotificationsButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject notificationsPanel;
    public void OnPointerClick(PointerEventData eventData)
    {
        notificationsPanel.SetActive(!notificationsPanel.active);
    }
}
