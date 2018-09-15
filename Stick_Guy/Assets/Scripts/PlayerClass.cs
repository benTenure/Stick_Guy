using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {

    //Class members
    int wins;
    bool isInMiniGame;

    //Initialize variables
    private void Start()
    {
        wins = 0;
        isInMiniGame = false;
    }

    //If player wins a mini game
    void winGame() {
        wins++;
    }

    //If player loses a mini game
    void loseGame() {
        wins--;
    }

    //Getter for wins member (used by game manager)
    public int getWins() {
        return wins;
    }

    //Getter for the mini game status member (used by game manager)
    public bool getGameStatus()
    {
        return isInMiniGame;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Set the "isInMiniGame" bool to true (One player should do it FIRST)
        isInMiniGame = true;
        print("Game has started");
        //Start a mini game with the other player
    }

}
