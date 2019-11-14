using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CruiserHoverMenu : HUDHoverMenu
{
    [SerializeField] protected Image cruiserIconPrefab;

    public override void onHover()
    {
        openMenu();
    }

    protected override void createMenuItems()
    {
        if(entryPrefab == null) {
            entryPrefab = cruiserIconPrefab;
        }
        Ship_Class[] cruisers = getShipsByType("Cruiser");
        InstantiateEntries(cruisers);
    }
}
