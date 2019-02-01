using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetAIScript : MonoBehaviour {

    // Self Movement Variables
    public float speed;

    // Chasing player variables
    public Transform playerPos;

	// Update is called once per frame
	void Update () {

        // From unity answers
        // https://answers.unity.com/questions/938221/basic-enemy-ai-in-c.html

        //Rotate to look at player
        //transform.LookAt(playerPos);
        transform.LookAt(new Vector3(playerPos.transform.position.x, playerPos.transform.position.y + 0.8f, playerPos.transform.position.z));
        //transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        // Move to the player
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));


        // Find the player

        // Move to the player

        // Update the player's CURRENT position

    }
}
