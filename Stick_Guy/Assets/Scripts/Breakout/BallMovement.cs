﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    private Transform rb;
    private float xVel = 0f;
    private float yVel = 0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Transform>();
        xVel = Random.Range(-20, 20); // starts with a random horizontal velocity
        yVel = Random.Range(10, 20); // starts with a random vertical velocity

        xVel /= 100;
        yVel /= 100;

    }

    // Update is called once per frame
    void Update()
    {
        rb.position += Vector3.down * (yVel);
        rb.position += Vector3.right * (xVel);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float random;
        random = Random.Range(-20, 20);
        if (collision.gameObject.name == "Wall1" || collision.gameObject.name == "Wall2")
        {
            xVel *= -1 + random / 500;
            yVel += random / 500;
        }
        if(collision.gameObject.name == "Ceiling")
        {
            yVel *= -1 + random / 500;
            xVel += random / 500;
        }
        if (collision.gameObject.name == "Paddle")
        {
            if (this.transform.position.x <= collision.gameObject.transform.position.x - 1.5) // Left side of paddle
            {
                if (xVel > 0)
                {
                    xVel *= -1 + random / 500;
                    yVel += random / 500;
                }
                random = Random.Range(-20, 20);
                yVel *= -1 + random / 500;
                xVel += random / 500;

            }
            else if (this.transform.position.x <= collision.gameObject.transform.position.x + 1.5) // Middle of paddle
            {
                yVel *= -1 + random / 500;
                xVel += random / 500;

            }
            else  // Right side of paddle if (this.transform.position.x <= collision.gameObject.transform.position.x + 4.5)
            {
                if (xVel < 0)
                {
                    xVel *= -1 + random / 500;
                    yVel += random / 500;
                }
                random = Random.Range(-20, 20);
                yVel *= -1 + random / 500;
                xVel += random / 500;

            }
        }
        // brick dimensions are .75 by .5
        if (collision.gameObject.name == "Brick(Clone)")

        {
            if (this.transform.position.y <= collision.gameObject.transform.position.y) // top side of brick
            {
                //print("TOP");
                yVel *= -1 + random / 500;
                xVel += random / 500;
            }
            else if (this.transform.position.x <= collision.gameObject.transform.position.x) // right side of brick
            {
               // print("RIGHT");
                xVel *= -1 + random / 500;
                yVel += random / 500;
            }
            else if (this.transform.position.y <= collision.gameObject.transform.position.y) // bottom side of brick
            {
              //  print("BOTTOM");
                yVel *= -1 + random / 500;
                xVel += random / 500;

            }
            else // left side of brick
            {
               // print("LEFT");
                xVel *= -1 + random / 500;
                yVel += random / 500;
            }
        }

       
    }
}