using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrigateHoverMenu : HUDHoverMenu
{
    [SerializeField] protected Image frigateIconPrefab;

    public override void onHover()
    {
        openMenu();
    }

    protected override void createMenuItems()
    {
        if(entryPrefab == null) {
            entryPrefab = frigateIconPrefab;
        }
        Ship_Class[] frigates = getShipsByType("Frigate");
        InstantiateEntries(frigates);
    }


}
