using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public static bool isPlayerDead = false;
    private Text gameOver;

	// Use this for initialization
	void Start () {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerDead)
        {
            // Basically pauses the game when you die
            Time.timeScale = 0;
            gameOver.enabled = true;
        }
	}
}
