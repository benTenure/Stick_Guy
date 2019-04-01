using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetAIScript : MonoBehaviour {

    // Self Movement Variables
    public float speed;

    // Chasing player variables
    public Transform playerPos;
    public PlayerInteractions pi;
    private Animator anim;

    private int health = 5;

    private void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        pi = p.GetComponent<PlayerInteractions>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        //Only chase if player is alive/active
        if (pi.playerActive)
        {
            anim.SetBool("playerAlive", true);

            // From unity answers
            // https://answers.unity.com/questions/938221/basic-enemy-ai-in-c.html

            //Rotate to look at player
            //transform.LookAt(playerPos);
            transform.LookAt(new Vector3(playerPos.transform.position.x, playerPos.transform.position.y + 0.8f, playerPos.transform.position.z));
            //transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            // Move to the player
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            anim.SetBool("playerAlive", false);
        }

    }

    public void hurtEnemy()
    {
        health -= 1;
        Debug.Log("Enemy has been hurt");
    }
/*
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            speed = 0;
            PlayerInteractions p = col.collider.GetComponent<PlayerInteractions>();
            p.HurtPlayer();
        }

    }
*/
}
