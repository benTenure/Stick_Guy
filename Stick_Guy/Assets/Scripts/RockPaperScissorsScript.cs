using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPaperScissorsScript : MonoBehaviour {

    public enum RPSValue { Rock, Paper, Scissors};

    private int playerChoice = -1;
    private int botChoice = -1;
    //private int player2Choice;

    private bool playerTurn = true;


    // Update is called once per frame
    void Update()
    {
        if (playerTurn && playerChoice == -1) return;

        else {

        }
    }

    public void playerChoose(int choice)
    {
        playerChoice = choice;
        playerTurn = false;
    }

    public void botChoose() {
        botChoice = Random.Range(0,2);
    }


    //OLD CODE, MIGHT USE FOR REFERENCE LATER. IGNORE FOR NOW.
    //
    //
    //public int RPSValue1;
    //public int RPSValue2;
    //public GameObject p1;
    //public GameObject p2;

    /*
    void Fight()
    {
        bool winner = false;

        while (winner == false)
        {
            //If Player 1 wins
            if ((RPSValue1 == 1 && RPSValue2 == 3) || (RPSValue1 == 2 && RPSValue2 == 1) || (RPSValue1 == 3 && RPSValue2 == 2))
            {
                p1.GetComponent<PlayerClass>().winGame();
                winner = true;
            }
            else if ((RPSValue2 == 1 && RPSValue1 == 3) || (RPSValue2 == 2 && RPSValue1 == 1) || (RPSValue2 == 3 && RPSValue1 == 2))
            {
                p2.GetComponent<PlayerClass>().winGame();
                winner = true;
            }
        } 
    }
*/
}
