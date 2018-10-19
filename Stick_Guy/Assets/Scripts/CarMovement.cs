using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    float speedForce = 35f;
    float torqueForce = 160f;
    float driftFactor = .9f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>(); //RigidBody COmponent Variable

        //Accelerate forward or reverse
        if (Input.GetKey(KeyCode.UpArrow)){
            rb.AddForce(transform.up * speedForce);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            rb.AddForce(transform.up * -speedForce/2);
        }


        //Accelerate backwards
        //Input.GetKey(KeyCode.DownArrow)

        rb.angularVelocity = Input.GetAxis("Horizontal") * -torqueForce;

        rb.velocity = ForwardVelocity() + RightVelocity()*driftFactor;
    }

    Vector2 ForwardVelocity(){
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity(){
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }
}
