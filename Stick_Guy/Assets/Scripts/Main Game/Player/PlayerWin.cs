using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public GameObject player;
    public GameObject winText;

    private bool canPlayAgain = false;

    private void Update()
    {
        if (canPlayAgain)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject;
            // Don't let player move/shoot, same for enemies
            player.GetComponent<PlayerInteractions>().playerActive = false;
            // Move player to win circle
            Vector3 winPosition = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
            Quaternion winRotation = new Quaternion(0f, 180f, 0f, 0f);
            
            player.transform.SetPositionAndRotation(winPosition, winRotation);

            player.GetComponent<MovementScript>().anim.SetBool("isWon", true);

            winText.SetActive(true);
            canPlayAgain = true;
        }
    }
}
