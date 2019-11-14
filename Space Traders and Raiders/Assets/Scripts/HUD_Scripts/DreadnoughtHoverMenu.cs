using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreadnoughtHoverMenu : HUDHoverMenu
{
    [SerializeField] protected Image dreadnoughtIconPrefab;

    public override void onHover()
    {
        openMenu();
    }

    protected override void createMenuItems()
    {
        if(entryPrefab == null) {
            entryPrefab = dreadnoughtIconPrefab;
        }
        Ship_Class[] dreadnoughts = getShipsByType("Dreadnought");
        InstantiateEntries(dreadnoughts);
    }
}
