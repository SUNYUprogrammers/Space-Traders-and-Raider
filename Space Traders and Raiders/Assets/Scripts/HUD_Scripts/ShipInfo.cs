using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipInfo : MonoBehaviour
{
    [SerializeField] Text shipInfoText;
    [SerializeField] Image shipInfoImage;

    [SerializeField] private Sprite[] frigateImages;
    [SerializeField] private Sprite[] cruiserImages;
    [SerializeField] private Sprite[] battleshipImages;
    [SerializeField] private Sprite[] destroyerImages;
    [SerializeField] private Sprite[] dreadnoughtImages;
    [SerializeField] private Sprite emptyImage;

    private Ship_Class ship;

    public void updateDisplay(Ship_Class ship, int colorIndex) {
        this.ship = ship;

        switch (ship.getShipType()) {
            case "Frigate":
                shipInfoImage.sprite = frigateImages[colorIndex];
            break;
            case "Cruiser":
                shipInfoImage.sprite = cruiserImages[colorIndex];
            break;
            case "Battleship":
                shipInfoImage.sprite = battleshipImages[colorIndex];
            break;
            case "Destroyer":
                shipInfoImage.sprite = destroyerImages[colorIndex];
            break;
            case "Dreadnought":
                shipInfoImage.sprite = dreadnoughtImages[colorIndex];
            break;
        }
        shipInfoImage.GetComponent<Image>().SetNativeSize();
        Color temp = shipInfoImage.GetComponent<Image>().color;
        temp.a = 1f;
        shipInfoImage.GetComponent<Image>().color = temp;

        shipInfoText.text = ship.getShipType();
    }

    public void clearDisplay() {
        if(ship != null) ship.selected = false;
        this.ship = null;
        shipInfoImage.sprite = emptyImage;
        Color temp = shipInfoImage.GetComponent<Image>().color;
        temp.a = 0f;
        shipInfoImage.GetComponent<Image>().color = temp;
        shipInfoText.text = "";
    }

    void Awake() {
      this.ship = null;
    }
}
