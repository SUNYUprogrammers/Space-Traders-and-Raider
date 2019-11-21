using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableSystem : SelectableGameObject
{
  public Canvas planetUI;

  new public void select()
  {
    this.selected = true;

    planetUI.enabled = true;
    planetUI.GetComponent<PlanetUI_script>().onSelect(this.gameObject);
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
}
