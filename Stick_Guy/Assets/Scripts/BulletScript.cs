using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed;
    public float deathCounter = 0.5f;

    // So we can give the player points
    public GameObject player;
    public PlayerInteractions PI;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PI = player.GetComponent<PlayerInteractions>();
    }

    // Update is called once per frame
    void Update () {

        deathCounter -= Time.deltaTime;

        if(deathCounter <= 0)
        {
            Destroy(gameObject);
        }

        // Actually moves the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // Call method to decrement life from enemy
            col.GetComponent<CabinetAIScript>().hurtEnemy();

            Debug.Log("We hit the enemy captain");
            PI.playerScore += 100;

            // Get rid of the bullet now
            Destroy(gameObject);

            // Maybe add particle effects at the point of collision so it leaves in a flashy light show!
        }
    }

}
