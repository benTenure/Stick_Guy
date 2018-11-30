using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Transform playerPosition;
    public float speed;
    public float leftBound, rightBound;

    public GameObject torpedo;
    public Transform torpedoSpawn;
    public float fireRate;

    private float nextFire;

    // Use this for initialization
    void Start()
    {
        playerPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputSpeed = Input.GetAxis("Horizontal");

        if (playerPosition.position.x < leftBound && inputSpeed < 0)
        {
            inputSpeed = 0;
        }
        else if (playerPosition.position.x > rightBound && inputSpeed > 0)
        {
            inputSpeed = 0;
        }
        //this.transform 

        playerPosition.position += Vector3.right * inputSpeed * speed;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(torpedo, torpedoSpawn.position, torpedoSpawn.rotation);
        }
    }
}









