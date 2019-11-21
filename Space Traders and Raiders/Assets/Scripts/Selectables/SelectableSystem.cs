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
  }

  new public void deselect()
  {
    this.selected = false;

    planetUI.enabled = false;
  }

  new public void setSelected(bool s)
  {
    this.selected = s;

    planetUI.enabled = s;
  }
}
