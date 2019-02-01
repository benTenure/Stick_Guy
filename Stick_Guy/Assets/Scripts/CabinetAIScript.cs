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

        //rotate to look at player
        transform.LookAt(playerPos);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        // Move to the player
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));


        // Find the player

        // Move to the player

        // Update the player's CURRENT position

    }
}
