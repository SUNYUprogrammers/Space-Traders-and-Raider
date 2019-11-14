using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyerHoverMenu : HUDHoverMenu
{
    [SerializeField] protected Image destroyerIconPrefab;

    public override void onHover()
    {
        openMenu();
    }

    protected override void createMenuItems()
    {
        if(entryPrefab == null) {
            entryPrefab = destroyerIconPrefab;
        }
        Ship_Class[] destroyers = getShipsByType("Destroyer");
        InstantiateEntries(destroyers);
    }
}
