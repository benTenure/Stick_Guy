using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    //Hardcode 2 players for now
    public GameObject p1;
    public GameObject p2;
    public GameObject WinnerText;

    //Hardcoding RPS into main game for now
    public enum RPSValue { Rock, Paper, Scissors };

    private int player1Choice = -1;
    private int player2Choice = -1;
    //private int botChoice = -1;

    private bool player1Turn = true;
    private bool player2Turn = false;

    private void Update()
    {
        //"Wait" for player input
        if ((player1Turn && player1Choice == -1) /*&& (player2Turn && player2Choice == -1)*/) return;

        else
        {
            //BotChoose();
            CheckWinner();
            player1Choice = -1;
            player1Turn = true;
            player2Choice = -1;
            player2Turn = true;
        }
    }

    void CheckWinner() {
        if (player1Choice == player2Choice) {
            //Draw
            WinnerText.GetComponent<Text>().text = "Draw";
        }

        //Winning Situations (from p1 perspective)
        else if (player1Choice == (int)RPSValue.Rock && player2Choice == (int)RPSValue.Scissors) {
            //Player 1 Wins!
            WinnerText.GetComponent<Text>().text = "Player 1 Wins";
        }
        else if (player1Choice == (int)RPSValue.Paper && player2Choice == (int)RPSValue.Rock)
        {
            //Player 1 Wins!
            WinnerText.GetComponent<Text>().text = "Player 1 Wins";
        }
        else if (player1Choice == (int)RPSValue.Scissors && player2Choice == (int)RPSValue.Paper)
        {
            //Player 1 Wins!
            WinnerText.GetComponent<Text>().text = "Player 1 Wins";
        }

        //Losing Situations (from p1 perspective)
        else if (player1Choice == (int)RPSValue.Scissors && player2Choice == (int)RPSValue.Rock)
        {
            //Player 2 Wins!
            WinnerText.GetComponent<Text>().text = "Player 2 Wins";
        }
        else if (player1Choice == (int)RPSValue.Rock && player2Choice == (int)RPSValue.Paper)
        {
            //Player 2 Wins!
            WinnerText.GetComponent<Text>().text = "Player 2 Wins";
        }
        else if (player1Choice == (int)RPSValue.Paper && player2Choice == (int)RPSValue.Scissors)
        {
            //Player 2 Wins!
            WinnerText.GetComponent<Text>().text = "Player 2 Wins";
        }
    }

    public void Player1Choose(int choice)
    {
        player1Choice = choice;
        player1Turn = false;
    }

    public void Player2Choose(int choice) 
    {
        player2Choice = choice;
        player2Turn = false;
    }

    public void BotChoose(int choice)
    {
        player2Choice = choice;
        player2Turn = false;
        //botChoice = Random.Range(0, 2);
    }

    //Check who wins a mini game (of 2 players, best of 5)
    void WhoIsWinning(PlayerClass p1, PlayerClass p2) {

        if (p1.getWins() == 3) {
            print("Player 1 wins");
        }
        else if (p2.getWins() == 3) {
            print("Player 2 wins");
        }
    }

}
