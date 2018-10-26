using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Brick"))
        {
            // check whether the box was hit on it's side or bottom 

            
            // Update ball's velocity
            
            
        }
    }

    private void changeTrajectoryHorizontal()
    {
        // x movement * -1
    }

    private void changeTrajectoryVertical()
    {
        // y movement * -1
    }
}
