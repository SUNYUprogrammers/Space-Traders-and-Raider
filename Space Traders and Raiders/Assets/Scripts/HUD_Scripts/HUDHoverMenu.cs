using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HUDHoverMenu : MonoBehaviour, IHUDHoverable
{
    public abstract void onHover();
    protected bool opening;
    protected bool closing;
    [SerializeField] protected Image background;
    protected Image entryPrefab;
    [SerializeField] protected Image mask;
    protected float expansionRate = 7;
    protected float iconBufferSpace = 5;
    protected float initialBufferspace = 10; //the buffer space between the first icon and edge of the menu
    protected float closedXBackground;
    protected float initialCloseDelay = .5f;
    protected float closeDelay = .5f;
    private List<MenuEntry> menuEntries;

    private bool isOpen = false;
    private bool isClosed = true;

    private float waitTimeBeforeClose = 1f;
    private float currentClosetimer = 0;

    private Canvas canvas;

    void Awake() {
        opening = false;
        menuEntries = new List<MenuEntry>();
        entryPrefab = null;
    }

    void Start() {
        canvas = GameObject.FindObjectOfType<Canvas>();
        Vector3 backgroundClosedRelative = canvas.transform.InverseTransformPoint(background.rectTransform.position);
        closedXBackground = backgroundClosedRelative.x;

        //Debug.Log("closedX: " + closedX);
    }



    protected abstract void createMenuItems();

    protected void openMenu() {
        closing = false;
        isClosed = false;
        if(!opening) {
            createMenuItems();
            opening = true;
        } else {
            foreach (MenuEntry entry in menuEntries)
            {
                entry.opening = true;
            }
        }
        if(menuEntries.Count == 0)  {
            opening = false;
            return;
        }
        closeDelay = initialCloseDelay;

        //TODO Figure out why background is not opening to desired width
        float targetX = closedXBackground + menuEntries.Count * (GetComponent<RectTransform>().rect.width + iconBufferSpace) + initialBufferspace/2;
        //Debug.Log("pos: " + background.rectTransform.position.x);
        //Debug.Log("targetX: " + targetX);

        Vector3 backgroundRelative = canvas.transform.InverseTransformPoint(background.rectTransform.position);

        if(backgroundRelative.x >= targetX) {
            opening = false;
            isOpen = true;
            //background.rectTransform.position = new Vector3(targetX, background.rectTransform.position.y, background.rectTransform.position.z);
            currentClosetimer = 0;
            return;
        }
        background.rectTransform.position += new Vector3(expansionRate, 0, 0);

    }


    protected void closeMenu() {
        closing = true;
        opening = false;
        isOpen = false;
        if(closeDelay > 0) {
            closeDelay -= Time.deltaTime;
            return;
        }

        foreach(MenuEntry entry in menuEntries) {
            entry.opening = false;
            entry.open = false;
        }

        float targetX = closedXBackground;

        Vector3 backgroundRelative = canvas.transform.InverseTransformPoint(background.rectTransform.position);

        if(backgroundRelative.x <= targetX) {
            opening = false;
            isClosed = true;
            closing = false;
            foreach(MenuEntry entry in menuEntries) {
                Destroy(entry.gameObject);
            }
            menuEntries.Clear();
            return;
        }

        background.rectTransform.position += new Vector3(-expansionRate, 0, 0);
    }

     protected Ship_Class[] getShipsByType(string type) {
        GameManager manager = FindObjectOfType<GameManager>();
        Player_Class player = manager.currentPlayer;
        Ship_Class[] ships = player.getPlayerShips(player.playerFaction);

        List<Ship_Class> matchingShips = new List<Ship_Class>();
        Debug.Log("Length: " + ships.Length);
        foreach(Ship_Class ship in ships) {

            //TODO clean this up with an enum or something
            Debug.Log("Ship: " + ship);
            Debug.Log("Type: " + type);
            Debug.Log("Ship.getType: " + ship.getShipType());
            if(ship.getShipType().Equals(type)) {
                matchingShips.Add(ship);
            }
        }
        return matchingShips.ToArray();
    }

    protected void InstantiateEntries(Ship_Class[] ships) {
        for(int i = 0; i< ships.Length; i++) {
            Image img = Instantiate(entryPrefab, transform.position, Quaternion.identity);

            MenuEntry entry = img.gameObject.AddComponent<MenuEntry>();
            img.transform.SetParent(mask.transform);
            img.gameObject.transform.localScale = new Vector3(entryPrefab.transform.localScale.x, entryPrefab.transform.localScale.y, entryPrefab.transform.localScale.z);

            menuEntries.Add(entry);

            entry.ship = ships[i];
            entry.expansionRate = expansionRate;
            entry.opening = true;
            entry.xOpen = mask.transform.position.x + i * (entryPrefab.rectTransform.rect.width + iconBufferSpace) + initialBufferspace;
            entry.xClosed = transform.position.x;

        }
    }

    void Update()
    {

        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        Vector3 canvasRelative = canvas.transform.InverseTransformPoint(transform.position);

        if(opening) {
            openMenu();
            return;
        }
        if(closing) {
            closeMenu();
            return;
        }
        if(HUD.IsPointerOverUIElement(this.gameObject) || (HUD.IsPointerOverUIElement(mask.gameObject) && HUD.IsPointerOverUIElement(background.gameObject))) {
            if(isOpen) return;
            openMenu();
        } else {
            if(isClosed) return;

            if(currentClosetimer >= waitTimeBeforeClose) {
                closeMenu();
            } else {
                currentClosetimer += Time.deltaTime;
            }
        }

        /*if(isOpen && (!HUD.IsPointerOverUIElement(this.gameObject)
           && !(HUD.IsPointerOverUIElement(mask.gameObject) && HUD.IsPointerOverUIElement(background.gameObject)))) {
            closeMenu();
        }*/
    }


}
