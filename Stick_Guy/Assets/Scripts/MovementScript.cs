using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    //Variable Declarations
    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public float speed;
    public float allowPlayerRotation;

    public Animator anim;
    public Camera cam;
    public CharacterController controller;

    private float verticalVelocity;
    private Vector3 moveVector;
        


	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        InputMagnitude();
	}

    void PlayerMoveAndRotation() {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        float div = 0.2f;

        controller.Move(new Vector3(InputX * div, 0, InputZ * div));

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (blockRotationPlayer == false) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }
    }

    void InputMagnitude() {

        //Calculate input vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        anim.SetFloat("InputX", InputX, 0.0f, Time.deltaTime * 2f);
        anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime * 2f);

        //Calculate input magnitude (for controlling animations)
        speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player
        if (speed > allowPlayerRotation) {
            anim.SetFloat("InputMagnitude", speed, 0.0f, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (speed < allowPlayerRotation) {
            anim.SetFloat("InputMagnitude", speed, 0.0f, Time.deltaTime);
        }

    }
}
