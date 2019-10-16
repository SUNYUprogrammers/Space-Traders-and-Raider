using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HUDHoverMenu : MonoBehaviour, IHUDHoverable
{
    public abstract void onHover();
    protected bool isOpen;
    [SerializeField] protected Image background;
    [SerializeField] protected Image entryPrefab;
    [SerializeField] protected Image mask;
    protected float expansionRate = 7;
    protected float iconBufferSpace = 5;
    protected float initialBufferspace = 10; //the buffer space between the first icon and edge of the menu
    protected float closedX;
    protected float initialCloseDelay = .5f;
    protected float closeDelay = .5f;

    private List<MenuEntry> menuEntries;

    void Awake() {
        isOpen = false;
        menuEntries = new List<MenuEntry>();
    }

    void Start() {
        closedX = background.rectTransform.position.x;
        //Debug.Log("closedX: " + closedX);
    }

    private void createMenuItems(int numItems) {
        for(int i = 0; i< numItems; i++) {
            Image img = Instantiate(entryPrefab, transform.position, Quaternion.identity);
            MenuEntry entry = img.gameObject.AddComponent<MenuEntry>();
            entry.transform.SetParent(mask.transform, false);
            entry.transform.position = mask.transform.position;
            
            menuEntries.Add(entry);
            entry.expansionRate = expansionRate;
            entry.opening = true;

            //Why do I need to put a .5f in here?
            entry.xOpen = mask.transform.position.x + i * (entryPrefab.rectTransform.rect.width * .5f  + iconBufferSpace) + initialBufferspace;
            entry.xClosed = transform.position.x;
        }
        
    }

    protected void openMenu(int numItems) {
        if(!isOpen) {
            createMenuItems(numItems);
        } else {
            foreach (MenuEntry entry in menuEntries)
            {
                entry.opening = true;
            }
        }
        isOpen = true;
        closeDelay = initialCloseDelay;

        
        float targetX = closedX + numItems * (entryPrefab.rectTransform.rect.width * .5f + iconBufferSpace) + initialBufferspace/2;
        //Debug.Log("pos: " + background.rectTransform.position.x);
        //Debug.Log("targetX: " + targetX);

        if(background.rectTransform.position.x >= targetX) {
            background.rectTransform.position = new Vector3(targetX, background.rectTransform.position.y, background.rectTransform.position.z);
            return;
        }
        background.rectTransform.position += new Vector3(expansionRate, 0, 0);
         
    }
    

    protected void closeMenu() {
        
        if(closeDelay > 0) {
            closeDelay -= Time.deltaTime;
            return;
        }

        foreach(MenuEntry entry in menuEntries) {
            entry.opening = false;
            entry.open = false;
        }

        float targetX = closedX;
        if(background.rectTransform.position.x <= targetX) {
            isOpen = false;
            foreach(MenuEntry entry in menuEntries) {
                Destroy(entry.gameObject);
            }
            menuEntries.Clear();
            return;
        }
        
        background.rectTransform.position += new Vector3(-expansionRate, 0, 0);
    }
    
    void Update()
    {
        if(HUD.IsPointerOverUIElement(this.gameObject) || (HUD.IsPointerOverUIElement(mask.gameObject) && HUD.IsPointerOverUIElement(background.gameObject))) {
            openMenu(7);
        } else {
            closeMenu();
        }

        /*if(isOpen && (!HUD.IsPointerOverUIElement(this.gameObject) 
           && !(HUD.IsPointerOverUIElement(mask.gameObject) && HUD.IsPointerOverUIElement(background.gameObject)))) {
            closeMenu();
        }*/
    }
}
