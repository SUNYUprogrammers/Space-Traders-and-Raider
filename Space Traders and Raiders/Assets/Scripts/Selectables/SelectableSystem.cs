using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableSystem : SelectableGameObject
{
  public Canvas planetUI;

    public Player_Class owner;

    protected Facilities_Class[] facilities = new Facilities_Class[5];
    public StarSystem self;
    public GameManager gm;

    public void Start()
    {
        owner = self.owner;
        print(self.owner);

        int temp = 0;

        foreach (Facilities_Class i in facilities)
        {
            facilities[temp] = null;
            temp++;
        }
        gm = GameObject.FindObjectOfType<GameManager>();

    }

    new public void select()
    {
        this.selected = true;

        planetUI.enabled = true;
        planetUI.GetComponent<PlanetUI_script>().onSelect(this.gameObject);
        gm = GameObject.FindObjectOfType<GameManager>();
    }

  new public void deselect()
  {
    this.selected = false;

    planetUI.enabled = false;
    planetUI.GetComponent<PlanetUI_script>().onSelect(null);
  }

  new public void setSelected(bool s)
  {
    this.selected = s;

    planetUI.enabled = s;
  }

    public void buildFacility(Facilities_Class i, bool cost)
    {
        print("Building " + i.getTypeString());

        if (this.owner != null)
        {
            i.faction = this.owner.playerFaction;
            print("Owner");

            i.self = new Color(this.owner.PlayerColor.r, this.owner.PlayerColor.g, this.owner.PlayerColor.b, .5f);

            if (facilities[i.getType()] == null)
                facilities[i.getType()] = i;
            else
            {
                int temp;
                temp = facilities[i.getType()].getTier();
                temp++;
                if (temp < 6)
                {
                    facilities[i.getType()].setTier(temp);
                }
                else
                    print("Max tier structure");
            }

            if (cost)
            {
                gm.calcResources(i.getTier(), i.getType(), owner);
            }
        }
        else
        {
            buildFacility(i, cost, gm.currentPlayer);
            cost = false;
        }
        
    }

    public void buildFacility(Facilities_Class i, bool cost, Player_Class fact)
    {
        print("Building(2) " + i.getTypeString());

        i.faction = fact.playerFaction;
        i.self = new Color(fact.PlayerColor.r, fact.PlayerColor.g, fact.PlayerColor.b, .5f);

        if (facilities[i.getType()] == null)
            facilities[i.getType()] = i;
        else
        {
            int temp;
            temp = facilities[i.getType()].getTier();
            temp++;
            if (temp < 6)
            {
                facilities[i.getType()].setTier(temp);
            }
            else
            {
                print("Max tier structure");
                cost = false;
            }
        }

        if (cost)
        {
            gm.calcResources(i.getTier()-1, i.getType(), fact);
        }
    }
}
