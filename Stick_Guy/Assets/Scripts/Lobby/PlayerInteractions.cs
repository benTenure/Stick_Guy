using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour {

    enum playerStates
    {
        NORMAL,
        FIGHT4LIFE,
        DEAD
    };

    private int currentState = (int)playerStates.NORMAL;

    public Text scoreText;
    public Text lifeText;

    public int playerScore;
    public int playerLives;

    public float bounce;

    private Rigidbody rb;

    public MovementScript ms;

    private void Start()
    {
        playerScore = 0;
        playerLives = 3;
        ms = GetComponent<MovementScript>();
        rb = GetComponent<Rigidbody>();
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

    public void HurtPlayer()
    {
        rb.AddForce(Vector3.back * bounce);

        playerLives -= 1;
        Debug.Log("Ouchie! We've been hit!");
    }
}
