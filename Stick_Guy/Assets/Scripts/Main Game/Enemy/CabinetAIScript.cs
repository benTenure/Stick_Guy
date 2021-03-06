﻿using System.Collections;
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

        playerPos = p.transform;
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
            transform.LookAt(playerPos);

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
    }
}
