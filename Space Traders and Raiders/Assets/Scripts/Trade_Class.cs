using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trade_Class : MonoBehaviour
{
    GameManager gm;
    int PlayerRes;
    int PlayerResRequested;
    int NumberHolderForPlayer1;
    int NumberHolderForPlayer2;
    public Player_Class MainTrader;
    public Player_Class SecondTrader;
    public InputField inputForPlayer1;
    public InputField inputForPlayer2;
    public Canvas Trade_GUI;
    public Canvas TradeConfirmation;

   

    public void TradeBtn()
    {

        Trade_GUI.GetComponent<Canvas>().enabled = true;

        gm = GameObject.FindObjectOfType<GameManager>();

        MainTrader = gm.currentPlayer;

        if(MainTrader == gm.players[0])
        {
            SecondTrader = gm.players[1];
        }else
        {
            SecondTrader = gm.players[0];
        }

        PlayerRes = (MainTrader.getRareMineral()) + (MainTrader.getCommonMineral()) + (MainTrader.getVeryRareMineral());
        print("Resources: " + PlayerRes );
        PlayerResRequested = (SecondTrader.getRareMineral()) + (SecondTrader.getCommonMineral()) + (SecondTrader.getVeryRareMineral());
    }

    public void tradeOffer()
    {
       

        print(NumberHolderForPlayer1);
    }

    public void tradeAccept()
    {
        NumberHolderForPlayer1 = int.Parse(inputForPlayer1.text);
        NumberHolderForPlayer2 = int.Parse(inputForPlayer2.text);

        if(NumberHolderForPlayer1 <= PlayerRes)
        {
            
            Trade_GUI.GetComponent<Canvas>().enabled = false;
            TradeConfirmation.GetComponent<Canvas>().enabled = true;
        }else
        {
            print("Insufficient Minerals");
        }
    }
    public void tradeConfirmAccept()
    {
        if (NumberHolderForPlayer2 <= PlayerRes)
        {
            Trade_GUI.GetComponent<Canvas>().enabled = false;


            PlayerRes += NumberHolderForPlayer2;
            PlayerRes -= NumberHolderForPlayer1;
            PlayerResRequested -= NumberHolderForPlayer2;
            PlayerResRequested += NumberHolderForPlayer1;

        TradeConfirmation.GetComponent<Canvas>().enabled = false;

        }else
        {
            print("Insufficient Minerals");
        }
        print(PlayerRes + "Vs" + PlayerResRequested);

    }

    public void tradeConfirmDecline()
    {
        TradeConfirmation.GetComponent<Canvas>().enabled = false; 
    }

    public void tradeRequestDecline()
    {
        Trade_GUI.GetComponent<Canvas>().enabled = false;
    }

}
