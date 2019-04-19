using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    // Float values for controlling animations
    public float InputX;
    public float InputZ;

    // Necessary components
    public Animator anim;
    public Camera cam;
    private Rigidbody rb;
    public GunScript gun;
    public PlayerInteractions pi;

    // Booleans for "states"
    public bool canMove;

    // New (Old really) movement
    private Vector3 moveInput;
    public Vector3 moveVelocity; // changing this to public so SwiftSoda can access it
    public float moveSpeed;
    private float pressRightTrigger;

	// Use this for initialization
	void Start () {
        pi = this.GetComponent<PlayerInteractions>();
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        // Make sure the player can do stuff
        canMove = pi.playerActive;
        //print("Can you move: " + canMove);

        // Need absolute values because negatives dont make anims work :(
        InputX = Mathf.Abs(Input.GetAxis("Horizontal"));
        InputZ = Mathf.Abs(Input.GetAxis("Vertical"));

        // If player is in a state that allows movement
        // (Right now that means not in a cutscene/animation)
        if (canMove == true)
        {
            // Creates vector for new movement
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * moveSpeed;

            // Send current "speeds" to animation controller
            anim.SetFloat("InputX", InputX);
            anim.SetFloat("InputZ", InputZ);

            // ALWAYS check if trigger is being pushed
            pressRightTrigger = Input.GetAxisRaw("Fire1");

            // Shooting your gun
            if (pressRightTrigger > 0)
            {
                gun.isFiring = true;
            }
                
            else
            {
                gun.isFiring = false;
            }
             

            if (pi.playerLives <= 0)
            {
                gun.isFiring = false;

            }

            // Using the right stick for rotation of character
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("R_Horizontal") + Vector3.forward * -Input.GetAxisRaw("R_Vertical");

            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
        }
        
	}

    void FixedUpdate()
    {
        // This actually moves the player
        rb.velocity = moveVelocity;
    }

}
