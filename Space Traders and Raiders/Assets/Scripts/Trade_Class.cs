using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trade_Class : MonoBehaviour
{
    GameManager gm;	
	public Canvas errorCanvas;
	public Canvas errorConfirmCanvas;

	public Text p1CmnTxt;
	public Text p1RareTxt;
	public Text p1VRTxt;
	public Text p2CmnTxt;
	public Text p2RareTxt;
	public Text p2VRTxt;

	public Text errorTxt;

    int PlayerCmnRes;
    int PlayerCmnResRequested;

	int PlayerRareRes;
    int PlayerRareResRequested;

	int PlayerVeryRareRes;
    int PlayerVeryRareResRequested;

    int InputCmnHolder;
    int InputCmnHolderP2;

	int InputRareHolder;
    int InputRareHolderP2;

	int InputVeryRareHolder;
    int InputVeryRareHolderP2;

    public Player_Class MainTrader;
    public Player_Class SecondTrader;

    public InputField inputForPlayer1Cmn;
    public InputField inputForPlayer2Cmn;

	public InputField inputForPlayer1Rare;
    public InputField inputForPlayer2Rare;

	public InputField inputForPlayer1VeryRare;
    public InputField inputForPlayer2VeryRare;

    public Canvas Trade_GUI;
    public Canvas TradeConfirmation;

 
    public void TradeBtn()
    {
		inputForPlayer1Cmn.text = "";
		inputForPlayer2Cmn.text = "";
		inputForPlayer1Rare.text = "";
		inputForPlayer2Rare.text = "";
		inputForPlayer1VeryRare.text = "";
		inputForPlayer2VeryRare.text = "";
        Trade_GUI.GetComponent<Canvas>().enabled = true;
        gm = GameObject.FindObjectOfType<GameManager>();
		
		

        //PlayerCmnRes = MainTrader.getCommonMineral();
        //print("Resources: " + PlayerCmnRes );
        //PlayerCmnResRequested = SecondTrader.getCommonMineral();
    }

    public void tradeOffer()
    {
        print(InputCmnHolder);
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
        print("Common Resources: " + PlayerCmnRes);
        PlayerCmnResRequested = SecondTrader.getCommonMineral();
        InputCmnHolder = int.Parse(inputForPlayer1Cmn.text);
        InputCmnHolderP2 = int.Parse(inputForPlayer2Cmn.text);

		PlayerRareRes = MainTrader.getRareMineral();
        print("Rare Resources: " + PlayerRareRes);
        PlayerRareResRequested = SecondTrader.getRareMineral();
        InputRareHolder = int.Parse(inputForPlayer1Rare.text);
        InputRareHolderP2 = int.Parse(inputForPlayer2Rare.text);

		PlayerVeryRareRes = MainTrader.getVeryRareMineral();
        print("Very Rare Resources: " + PlayerVeryRareRes);
        PlayerVeryRareResRequested = SecondTrader.getVeryRareMineral();
        InputVeryRareHolder = int.Parse(inputForPlayer1VeryRare.text);
        InputVeryRareHolderP2 = int.Parse(inputForPlayer2VeryRare.text);
		
		
		
		
        if(InputCmnHolder <= PlayerCmnRes && InputRareHolder <= PlayerRareRes && InputVeryRareHolder <= PlayerVeryRareRes)
        {
            
            Trade_GUI.GetComponent<Canvas>().enabled = false;
            TradeConfirmation.GetComponent<Canvas>().enabled = true;
			 p1CmnTxt.text = inputForPlayer1Cmn.text;
			 p1RareTxt.text = inputForPlayer1Rare.text;
			 p1VRTxt.text = inputForPlayer1VeryRare.text;
			 p2CmnTxt.text = inputForPlayer2Cmn.text;
			 p2RareTxt.text = inputForPlayer2Rare.text;
			 p2VRTxt.text = inputForPlayer2VeryRare.text;
        }else
        {
            print(InputCmnHolder + ": "+ PlayerCmnRes);
			errorCanvas.enabled= true;
            print("Insufficient Minerals");


        }
    }
    public void tradeConfirmAccept()
    {
        if (InputCmnHolderP2 <= PlayerCmnResRequested && InputRareHolderP2 <= PlayerRareResRequested && InputVeryRareHolderP2 <= PlayerVeryRareResRequested)
        {
            Trade_GUI.GetComponent<Canvas>().enabled = false;


            PlayerCmnRes += InputCmnHolderP2;
            PlayerCmnRes -= InputCmnHolder;
            PlayerCmnResRequested -= InputCmnHolderP2;
            PlayerCmnResRequested += InputCmnHolder;

			PlayerRareRes += InputRareHolderP2;
            PlayerRareRes -= InputRareHolder;
            PlayerRareResRequested -= InputRareHolderP2;
            PlayerRareResRequested += InputRareHolder;

			PlayerVeryRareRes += InputVeryRareHolderP2;
            PlayerVeryRareRes -= InputVeryRareHolder;
            PlayerVeryRareResRequested -= InputVeryRareHolderP2;
            PlayerVeryRareResRequested += InputVeryRareHolder;

            MainTrader.setCommonMineral(PlayerCmnRes);
			MainTrader.setRareMineral(PlayerRareRes);
			MainTrader.setVeryRareMineral(PlayerVeryRareRes);

            SecondTrader.setCommonMineral(PlayerCmnResRequested);
			SecondTrader.setRareMineral(PlayerRareResRequested);
			SecondTrader.setVeryRareMineral(PlayerVeryRareResRequested);

        TradeConfirmation.GetComponent<Canvas>().enabled = false;

        }else 
        {
			errorCanvas.enabled = true;
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

	public void tradeErrorBtn()
	{
		errorCanvas.enabled = false;
	}
	

}
