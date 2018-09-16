using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPaperScissorsScript : MonoBehaviour {

    //public enum RPSValue { Rock, Paper, Scissors};
    public int RPSValue1;
    public int RPSValue2;
    public GameObject p1;
    public GameObject p2;

	// Use this for initialization
	void Start ()
    {
        //RPSValue1 = Choose(p1);
        //RPSValue2 = Choose(p2);
    }
    
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

   /* int Choose(GameObject player)
    {
        int choice = 0;
        while (choice == 0)
        {
            if (Input.GetKeyDown("r"))
                choice = 1;
            else if (Input.GetKeyDown("p"))
                choice = 2;
            else if (Input.GetKeyDown("s"))
                choice = 3;
        }
        return choice;
    }
    */
	
	// Update is called once per frame
	void Update () {
		
	}

    void FindPlayers(GameObject p1, GameObject p2)
    {

    }
}
