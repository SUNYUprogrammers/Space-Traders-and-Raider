using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlanetUI_script : MonoBehaviour
{
    public GameObject self;

    public Image planet_img;
    public Text planet_name;

    public Shipyard_Class shipyard;
    public Player_Class pc;

    public GameObject[] ship_types = new GameObject[5];
    public Facilities_Class[] facil = new Facilities_Class[5];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<Canvas>().enabled)
        {
            //print(self.GetComponent<SpriteRenderer>().name);
            planet_img.sprite = self.GetComponent<SpriteRenderer>().sprite;
            planet_name.text = self.name;

            if(self.GetComponent<Mine_Class>() != null)
            {
                facil[0] = self.GetComponent<Mine_Class>();
            }
            if(self.GetComponent<Shipyard_Class>() != null)
            {
                shipyard = self.GetComponent<Shipyard_Class>();
                facil[1] = shipyard;
            }
            pc = GameObject.FindObjectOfType<GameManager>().currentPlayer;
            if (self.GetComponent<SDS_Class>() != null)
            {
                facil[2] = self.GetComponent<SDS_Class>();
            }
            if (self.GetComponent<Barracks_Class>() != null)
            {
                facil[3] = (Facilities_Class)self.GetComponent<Barracks_Class>();
            }
            if (self.GetComponent<TradeCenter_Class>() != null)
            {
                facil[4] = self.GetComponent<TradeCenter_Class>();
            }
        }
    }

    public void onSelect(GameObject i)
    {
        self = i;
    }

    public void buildModules(int i)
    {
        if(shipyard != null && true)
        {
            shipyard.component_storage[i]++;
            pc.chargeResources(0,0,0);                                      //Set to 0 for now, same with ship costs
        }
    }

    public void buildShips(int i)
    {
        if (shipyard != null && true)
        {
            Instantiate(ship_types[i],self.transform);
            pc.chargeResources(0, 0, 0);                                      //Set to 0 for now, same with ship costs
        }
    }

    public void buildFacilities(int i)
    {
        Facilities_Class temp;

        if (facil[i] != null)
        {
            temp = facil[i];
            self.GetComponent<SelectableSystem>().buildFacility(temp, true);
            
        }
        else
        {
            switch(i)
            {
                case 0:
                    if(true)
                    {
                        temp = self.AddComponent<Mine_Class>();
                        self.GetComponent<SelectableSystem>().buildFacility(temp, false);
                    }
                    break;
                case 1:
                    if (true)
                    {
                        temp = self.AddComponent<Shipyard_Class>();
                        self.GetComponent<SelectableSystem>().buildFacility(temp, false);
                    }
                    break;
                case 2:
                    if (true)
                    {
                        temp = self.AddComponent<SDS_Class>();
                        self.GetComponent<SelectableSystem>().buildFacility(temp, false);
                    }
                    break;
                case 3:
                    if (true)
                    {
                        temp = self.AddComponent<Barracks_Class>();
                        self.GetComponent<SelectableSystem>().buildFacility(temp, false);
                    }
                    break;
                case 4:
                    if (true)
                    {
                        temp = self.AddComponent<TradeCenter_Class>();
                        self.GetComponent<SelectableSystem>().buildFacility(temp, false);
                    }
                    break;
            }
        }
        
    }
}
