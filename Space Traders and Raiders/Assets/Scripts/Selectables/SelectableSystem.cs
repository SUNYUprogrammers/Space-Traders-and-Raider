using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableSystem : SelectableGameObject
{
  public GameObject planetUI;

  public void select(){
    this.selected = true;

    planetUI.SetActive(true);
  }

  public void deselect(){
    this.selected = false;

    planetUI.SetActive(false);
  }

  public void setSelected(bool s){
    this.selected = s;

    planetUI.SetActive(s);
  }
}
