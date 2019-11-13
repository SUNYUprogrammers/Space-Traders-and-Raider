using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableGameObject : MonoBehaviour
{
    protected bool selectable = true;
    [SerializeField] protected bool selected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isSelectable(){
      return this.selectable;
    }

    public void setSelectable(bool s){
      this.selectable = s;
    }

    public void select(){
      this.selected = true;
    }

    public void deselect(){
      this.selected = false;
    }

    public void setSelected(bool s){
      this.selected = s;
    }

    public bool isSelected(){
      return this.selected;
    }
}
