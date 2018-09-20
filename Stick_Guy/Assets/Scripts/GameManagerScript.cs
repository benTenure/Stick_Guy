using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    //Hardcode 2 players for now
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    private PlayerClass ps1;    //player script 1
    private PlayerClass ps2;    //player script 2

    //Variables for fetching UI components
    //private GameObject WinnerText;
    public GameObject Player1Menu;
    public GameObject Player2Menu;
    public GameObject WinnerScreen;

    //Hardcoding RPS into main game for now
    private enum RPSValue { Rock, Paper, Scissors };

    //Game keeping variables
    private int rounds = 0;
    private int player1Choice = -1;
    private int player2Choice = -1;
    private bool player1Turn = true;
    private bool player2Turn = false;

    private void Awake()
    {
        //Fetch the UI stuff
        /*
        Player1Menu = GameObject.Find("Player 1 Menu");
        Player2Menu = GameObject.Find("Player 2 Menu");
        WinnerScreen = GameObject.Find("Win Screen");
        */

        //Scripts needed from the players
        ps1 = p1.GetComponent<PlayerClass>();
        ps2 = p2.GetComponent<PlayerClass>();
    }

    private void Update()
    {

        if (ps1.GetGameStatus() == true)
        {
            Player1Menu.SetActive(true);
        }

        //"Wait" for player input
        //If player 1 hasn't taken their turn yet, then player 2 definitely hasn't either (only check for player 1)
        if ((player1Turn && player1Choice == -1)) return;

        else
        {
            //Check if both players have taken a turn
            if (player1Turn == false && player2Turn == false)
            {
                //Who won the round/game
                CheckWinner();

                //Reset players for another round/game
                player1Choice = -1;
                player1Turn = true;
                //ps1.SetGameStatus(false);

                player2Choice = -1;
                player2Turn = true;
                //ps2.SetGameStatus(false);
            }


            if (rounds >= 3)
            {
                WhoWonTheGame();
            }
        }
            
    }

    void CheckWinner() {
        if (player1Choice == player2Choice) {
            //Draw
            WinnerScreen.GetComponent<Text>().text = "Draw";

            //Should a round be counted if there was no winner?
            //rounds++;
        }

        //Winning Situations (from p1 perspective)
        else if (player1Choice == (int)RPSValue.Rock && player2Choice == (int)RPSValue.Scissors) {
            //Player 1 Wins!
            WinnerScreen.GetComponent<Text>().text = "Player 1 Wins";
            rounds++;
        }
        else if (player1Choice == (int)RPSValue.Paper && player2Choice == (int)RPSValue.Rock)
        {
            //Player 1 Wins!
            WinnerScreen.GetComponent<Text>().text = "Player 1 Wins";
            rounds++;
        }
        else if (player1Choice == (int)RPSValue.Scissors && player2Choice == (int)RPSValue.Paper)
        {
            //Player 1 Wins!
            WinnerScreen.GetComponent<Text>().text = "Player 1 Wins";
            rounds++;
        }

        //Losing Situations (from p1 perspective)
        else if (player1Choice == (int)RPSValue.Scissors && player2Choice == (int)RPSValue.Rock)
        {
            //Player 2 Wins!
            WinnerScreen.GetComponent<Text>().text = "Player 2 Wins";
            rounds++;
        }
        else if (player1Choice == (int)RPSValue.Rock && player2Choice == (int)RPSValue.Paper)
        {
            //Player 2 Wins!
            WinnerScreen.GetComponent<Text>().text = "Player 2 Wins";
            rounds++;
        }
        else if (player1Choice == (int)RPSValue.Paper && player2Choice == (int)RPSValue.Scissors)
        {
            //Player 2 Wins!
            WinnerScreen.GetComponent<Text>().text = "Player 2 Wins";
            rounds++;
        }
    }

    //Only starts to be checked after 3 rounds have been played and checked
    public void WhoWonTheGame()
    {
        if (ps1.GetWins() == 3)
        {
            //Bring up the "PLAYER 1 WINS" screen
            //End the game

            //ResetPlayers();
        }
        else if (ps2.GetWins() == 3)
        {
            //Bring up the "PLAYER 2 WINS" screen
            //End the game
        }
    }

    public void Player1Choose(int choice)
    {
        player1Choice = choice;
        player1Turn = false;
        Player1Menu.SetActive(false);
        Player2Menu.SetActive(true);
    }

    public void Player2Choose(int choice) 
    {
        player2Choice = choice;
        player2Turn = false;
        Player2Menu.SetActive(false);
        WinnerScreen.SetActive(true);
    }

    private void ResetPlayers()
    {
        ps1.SetGameStatus(false);
        ps2.SetGameStatus(false);
    }
}