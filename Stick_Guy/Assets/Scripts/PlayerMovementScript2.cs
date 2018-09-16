﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript2 : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    private Vector2 direction;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        Move();
	}

    public void Move(){
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void GetInput(){

        direction = Vector2.zero;
        //as it walks, the animator triggers update so we can see it walking (once it recognizes the trigger)
        if(Input.GetKey(KeyCode.UpArrow)){
            direction += Vector2.up;
           // Animator.SetTrigger(forwardWalk);
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            direction += Vector2.down;
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            direction += Vector2.left;
        }

        if(Input.GetKey(KeyCode.RightArrow)){
            direction += Vector2.right;
        }
    }
}
