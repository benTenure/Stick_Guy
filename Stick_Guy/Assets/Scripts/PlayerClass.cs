using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {

    int wins;

    //Default Constructor
    PlayerClass() {
        wins = 0;
    }

    //If player wins a mini game
    void winGame() {
        wins++;
    }

    //If player loses a mini game
    void loseGame() {
        wins--;
    }

    //Getter for wins memeber (used by game manager)
    public int getWins() {
        return wins;
    }

}
