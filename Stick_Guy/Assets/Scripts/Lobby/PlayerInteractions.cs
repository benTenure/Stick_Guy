using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour {

    // UI components
    public Text scoreText;
    public Text lifeText;

    // Player variables
    public int playerScore;
    public int playerLives;
    public float bounce;
    public bool playerActive;

    // Necessary Components
    private Rigidbody rb;
    public MovementScript ms;
    public Animator anim;
    public Animation death;

    private void Start()
    {
        playerActive = true;
        playerScore = 0;
        playerLives = 3;
        anim = this.GetComponent<Animator>();
        ms = GetComponent<MovementScript>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        scoreText.text = "SCORE: " + playerScore;
        lifeText.text = "LIFE: " + playerLives;

        if(playerActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerActive = false;
                SceneManager.LoadScene("SpaceInvaders", LoadSceneMode.Additive);
            }
        }

        // Ran out of lives?
        if (playerLives <= 0)
        {
            // You're dead bro
            playerActive = !playerActive;

            // Now we kill you
            anim.SetBool("isDead", true);
        }
    }

    public void HurtPlayer()
    {
        rb.AddForce(Vector3.back * bounce);

        playerLives -= 1;
        Debug.Log("Ouchie! We've been hit!");
    }
}
