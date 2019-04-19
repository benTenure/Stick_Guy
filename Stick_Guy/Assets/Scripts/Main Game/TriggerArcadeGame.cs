using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArcadeGame : MonoBehaviour
{
    private PlayerInteractions player;
    // reference to texture target

    private Rigidbody rb;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<PlayerInteractions>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (player.playerLives == 1)
            {
                player.playerActive = false;
                rb.transform.LookAt(col.transform);

                // Move camera to player
            }
        }
    }
}
