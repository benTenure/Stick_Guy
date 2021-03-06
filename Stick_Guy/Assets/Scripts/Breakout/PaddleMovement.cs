﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    public float moveSpeed = 10f;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        float movement = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(movement, 0);
        Vector2 movementVelocity = movementVector * moveSpeed;
        rb.velocity = movementVelocity;

        /*
        Vector2 movementVector = Vector2.zero;

        if (Input.GetAxis("Horizontal") < 0)
        {
            movementVector.x = (transform.right * Time.deltaTime * -moveSpeed).x;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            movementVector.x = (transform.right * Time.deltaTime * moveSpeed).x;
        }
            
        movementVector = movementVector + (Vector2)(transform.position);

        rb.MovePosition(movementVector);
        */
    }

}
