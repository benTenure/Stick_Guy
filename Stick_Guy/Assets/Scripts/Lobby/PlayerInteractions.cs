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
    private float timer = 2f;
    private bool wasUsed = false;
    private Vector3 targetPos;
    private bool notAttacked = true;
    private Vector3 direction;

    // Necessary Components
    private Rigidbody rb;
    public MovementScript ms;
    public Animator anim;
    public Animation death;
    public FadingTextScript gameOver;
    public FadeBlackScript blackScreen;
    public PowerUp pow;

    private void Start()
    {
        playerActive = true;
        playerScore = 0;
        playerLives = 4;
        anim = this.GetComponent<Animator>();
        ms = GetComponent<MovementScript>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        scoreText.text = "SCORE: " + playerScore;
        lifeText.text = "LIFE: " + playerLives;

        //Debug.Log("notAttacked: " + notAttacked);

        if(playerActive == true)
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
            playerActive = false;

            // Now we kill you
            anim.SetBool("isDead", true);

            timer -= Time.deltaTime;

            // Should only call the function ONE time
            if (timer <= 0 && wasUsed == false)
            {
                blackScreen.FadeIn();
                gameOver.FadeIn();
                wasUsed = true;
                //Debug.Log("We got called at least once!");
            }

        }
    }

    private void FixedUpdate()
    {
        if (notAttacked == true)
        {
            // Unless specified otherwise, we want to be at the position we are at.
            targetPos = transform.position;
        }
        else
        {
            targetPos = direction;

            // Smoothly transition the player to the new destination
            rb.MovePosition(transform.position + direction * bounce * Time.deltaTime);

            if (transform.position == targetPos)
            {
                notAttacked = true;
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // Calculate angle between the collision point and the player
            direction = col.contacts[0].point - transform.position;

            // Make it the opposite direction of enemy
            direction = -direction.normalized;

            // Move the player back
            //rb.AddForce(dir * bounce);
            //rb.MovePosition(direction * bounce);

            notAttacked = false;
            playerLives -= 1;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PowerUp")
        {
            // Make pick up disappear
            col.gameObject.SetActive(false);

            // Make actual power show up
            pow.StartPowerUp();
        }
    }
}
