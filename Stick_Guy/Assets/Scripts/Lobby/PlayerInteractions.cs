using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour {

    public Text scoreText;
    public Text lifeText;

    public int playerScore;
    public int playerLives;

    public MovementScript ms;

    private void Start()
    {
        playerScore = 0;
        playerLives = 3;
        ms = GetComponent<MovementScript>();
    }

    private void Update()
    {
        scoreText.text = "SCORE: " + playerScore;
        lifeText.text = "LIFE: " + playerLives;

        if(ms.canMove)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ms.canMove = false;
                SceneManager.LoadScene("SpaceInvaders", LoadSceneMode.Additive);
            }
        }
    }
}
