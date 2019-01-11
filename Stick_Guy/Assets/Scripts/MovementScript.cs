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

    public bool canMove = true;

    // New (Old really) movement
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public float moveSpeed;
    private float pressRightTrigger;
    private Rigidbody rb;

    public GunScript gun;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        // Creates vector for new movement
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        // ALWAYS check if trigger is being pushed
        pressRightTrigger = Input.GetAxisRaw("Fire1");

        // Shooting your gun
        if (pressRightTrigger > 0)
            gun.isFiring = true;
        else
            gun.isFiring = false;

        // Moving the player
        if (canMove)
        {
            InputMagnitude();
        }
        
	}

    void FixedUpdate()
    {
        // This actually moves the player
        rb.velocity = moveVelocity;
    }

    void PlayerMoveAndRotation() {
        // Rotating the player
        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }
    }

    void InputMagnitude() {

        //Calculate input vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        // anim.SetFloat("InputX", InputX, 0.0f, Time.deltaTime * 2f);
        // anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime * 2f);

        anim.SetFloat("InputX", InputX, 0.0f, Time.deltaTime);
        anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime);

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
