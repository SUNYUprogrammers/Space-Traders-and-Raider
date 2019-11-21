using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRenderController : MonoBehaviour
{
    public GameManager gameManager;
    public string faction;
    public bool renderOverride;
    public bool isRendering = true;
    private SpriteRenderer sr;

    private bool initCheckDone = false;

    // Start is called before the first frame update
    void Awake()
    {
      gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent("GameManager") as GameManager;
      gameManager.registerTurnRenderController(this);
      sr = GetComponent("SpriteRenderer") as SpriteRenderer;
    }

    // Update is called once per frame
    void Update()
    {
      if(!initCheckDone && gameManager.currentPlayer != null){
        initCheckDone = true;
        this.endTurn();
      }
    }

    public void endTurn(){
      if(gameManager.currentPlayer.playerFaction.Equals(this.faction)){
        isRendering = true;
      } else {
        isRendering = false;
      }
      sr.enabled = isRendering;
    }

    public void setup(string f){
      this.faction = f;
    }
}
