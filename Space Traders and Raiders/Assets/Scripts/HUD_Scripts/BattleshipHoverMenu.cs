using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleshipHoverMenu : HUDHoverMenu
{
    [SerializeField] protected Image battleShipIconPrefab;

    public override void onHover()
    {
        openMenu();
    }

    protected override void createMenuItems()
    {
        if(entryPrefab == null) {
            entryPrefab = battleShipIconPrefab;
        }
        Ship_Class[] battleships = getShipsByType("Battleship");
        InstantiateEntries(battleships);
    }
}
