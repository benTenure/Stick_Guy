using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    //Hardcode 2 players for now
    public GameObject p1;
    public GameObject p2;
    //private PlayerClass p1Script;
    //private PlayerClass p2Script;

    private void Update()
    {
        if (p1.GetComponent<PlayerClass>().getGameStatus())
        {
            startChallenge();
        }
        else if (p2.GetComponent<PlayerClass>().getGameStatus())
        {
            startChallenge();
        }
    }

    //Check who wins a mini game (of 2 players, best of 5)
    void whoIsWinning(PlayerClass p1, PlayerClass p2) {

        if (p1.getWins() == 3) {
            Win(p1);
        }
        else if (p2.getWins() == 3) {
            Win(p2);
        }
    }

    //Called when object is instantiated
    private void Start() {
        //p1Script = p1.GetComponent<PlayerClass>();
        //p2Script = p2.GetComponent<PlayerClass>();
    }

    //Selected player wins the game
    void Win(PlayerClass p) {

    }

    void startChallenge() {
        print("LET THE GAMES BEGIN.");
        print("Player1 status: " + p1.GetComponent<PlayerClass>().getGameStatus());
        print("Player2 status: " + p2.GetComponent<PlayerClass>().getGameStatus());
    }
}
