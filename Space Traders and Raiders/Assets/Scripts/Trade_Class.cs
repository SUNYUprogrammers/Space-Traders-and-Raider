using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trade_Class : MonoBehaviour
{
    GameManager gm;
    int PlayerCmnRes;
    int PlayerCmnResRequested;
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

       

        //PlayerCmnRes = MainTrader.getCommonMineral();
        //print("Resources: " + PlayerCmnRes );
        //PlayerCmnResRequested = SecondTrader.getCommonMineral();
    }

    public void tradeOffer()
    {
       

        print(NumberHolderForPlayer1);
    }

    public void tradeAccept()
    {
        MainTrader = gm.currentPlayer;

        if (MainTrader == gm.players[0])
        {
            SecondTrader = gm.players[1];
        }
        else
        {
            SecondTrader = gm.players[0];
        }
        PlayerCmnRes = MainTrader.getCommonMineral();
        print("Resources: " + PlayerCmnRes);
        PlayerCmnResRequested = SecondTrader.getCommonMineral();
        NumberHolderForPlayer1 = int.Parse(inputForPlayer1.text);
        NumberHolderForPlayer2 = int.Parse(inputForPlayer2.text);

        if(NumberHolderForPlayer1 <= PlayerCmnRes)
        {
            
            Trade_GUI.GetComponent<Canvas>().enabled = false;
            TradeConfirmation.GetComponent<Canvas>().enabled = true;
        }else
        {
            print(NumberHolderForPlayer1 + "/n"+ PlayerCmnRes);
            print("Insufficient Minerals");
        }
    }
    public void tradeConfirmAccept()
    {
        if (NumberHolderForPlayer2 <= PlayerCmnRes)
        {
            Trade_GUI.GetComponent<Canvas>().enabled = false;


            PlayerCmnRes += NumberHolderForPlayer2;
            PlayerCmnRes -= NumberHolderForPlayer1;
            PlayerCmnResRequested -= NumberHolderForPlayer2;
            PlayerCmnResRequested += NumberHolderForPlayer1;

            MainTrader.setCommonMineral(PlayerCmnRes);
            SecondTrader.setCommonMineral(PlayerCmnResRequested);

        TradeConfirmation.GetComponent<Canvas>().enabled = false;

        }else
        {
            print("Insufficient Minerals");
        }
        print(PlayerCmnRes + "Vs" + PlayerCmnResRequested);

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
