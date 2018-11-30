using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour {

    public GameObject prompt_L;
    public GameObject prompt_M;
    public GameObject prompt_R;
    public Text scoreText;

    public int playerScore;

    public MovementScript ms;

    private void Start()
    {
        playerScore = 0;
        ms = GetComponent<MovementScript>();
    }

    private void Update()
    {
        scoreText.text = "SCORE: " + playerScore;

        if(ms.canMove)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ms.canMove = false;
                SceneManager.LoadScene("SpaceInvaders", LoadSceneMode.Additive);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.name == "L Arcade Trigger")
        {
            prompt_L.gameObject.SetActive(true);
        }
        if (col.gameObject.name == "M Arcade Trigger")
        {
            prompt_M.gameObject.SetActive(true);
        }
        if (col.gameObject.name == "R Arcade Trigger")
        {
            prompt_R.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("Come back again sooN!");

        if (col.gameObject.name == "L Arcade Trigger")
        {
            prompt_L.gameObject.SetActive(false);
        }
        if (col.gameObject.name == "M Arcade Trigger")
        {
            prompt_M.gameObject.SetActive(false);
        }
        if (col.gameObject.name == "R Arcade Trigger")
        {
            prompt_R.gameObject.SetActive(false);
        }
    }
}
