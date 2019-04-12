using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TorpedoScript : MonoBehaviour {

    private Transform bullet;
    public float speed;

	// Use this for initialization
	void Start () {
        bullet = GetComponent<Transform>();	
	}
	
	void FixedUpdate () {
        bullet.position += Vector3.up * -speed;

        if (bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            GameOverScript.isPlayerDead = true;
        }
        else if (col.tag == "Base")
        {
            GameObject playerBase = col.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.health -= 1;
            Destroy(gameObject);
        }
    }
}
