using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour {

    private Transform bulletPos;
    public float bulletSpeed;

    private PlayerInteractions pi;

	// Use this for initialization
	void Start () {
        bulletPos = GetComponent<Transform>();
        pi = FindObjectOfType<PlayerInteractions>();
	}

    private void FixedUpdate()
    {
        bulletPos.position += Vector3.up * bulletSpeed;

        //Destroy projectile after reaching specified height
        if (bulletPos.position.y >= 15)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            //Destroy the enemy we touch
            Destroy(col.gameObject);

            //Destroy our own projectile
            Destroy(gameObject);

            //Add score to the player
            pi.playerScore += 500;
        }
        else if (col.tag == "Base")
        {
            //Destroy our own projectile
            Destroy(gameObject);
            
        }
    }
}
