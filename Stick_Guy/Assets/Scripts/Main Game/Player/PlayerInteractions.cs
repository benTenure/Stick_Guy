using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerInteractions : MonoBehaviour {

    // UI components
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;

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
    private bool canPlayAgain = false;

    // Necessary Components
    private Rigidbody rb;
    public MovementScript ms;
    public Animator anim;
    public FadingTextScript gameOver;
    public FadeBlackScript blackScreen;
    public PowerUp pow = null;
    public HealthBarScript hb;

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
        scoreText.text = "SCORE - " + playerScore;

        // Ran out of lives?
        if (playerLives <= 0)
        {
            // Reset everything sorta kinda
            rb.velocity = Vector3.zero;

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
                gameOverText.SetActive(true);
                wasUsed = true;
                canPlayAgain = true;
            }

            if (canPlayAgain)
            {
                if (Input.GetButtonDown("Fire3"))
                    SceneManager.LoadScene(0);
            }

        }
    }

    //REALLY NEED TO IMPLEMENT THIS, LIKE NOW!
    private void BouncePlayerBack()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            transform.LookAt(col.transform);

            notAttacked = false;
            playerLives -= 1;

            hb.ChangeHealth(playerLives);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PowerUp")
        {
            string powerUpName = col.name;
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[]) // looks through EACH game object (even ones that are inactive)
            {
                if (powerUpName == "Shield Pick Up" && go.name == "Shields")
                {
                    pow = go.GetComponent<Shields_PU>();
                    pow.StartPowerUp();
                }
                else if (powerUpName == "Spread Pick Up")
                {
                    if(go.name == "Bullet_Spawn_Left")
                    {
                        pow = go.GetComponent<Spread_PU>();
                        pow.StartPowerUp();
                    } else if(go.name == "Bullet_Spawn_Right")
                    {
                        pow = go.GetComponent<Spread_PU>();
                        pow.StartPowerUp();
                    }    
                }
            }
            col.gameObject.SetActive(false);
        }
    }
}
