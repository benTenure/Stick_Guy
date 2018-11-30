using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {

        

        int numBricks = 20; // this should changed, call a function to grab the constant number of bricks from the main script.

      
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnColliderEnter(Collider other)
    {
        for(int i = 1; i < 1; i++)
        {
        if (other.gameObject.name == "Brick")
            {
                // brick disappears
                // ball velocity changes
                
            }
        }
        
        Transform newSpot = GetComponent<Transform>();

        //if()
            // check what side the brick was hit

            
            // Update ball's velocity
            
            
        
    }

    private void ChangeTrajectoryHorizontal()
    {
        // x movement * -1
    }

    private void ChangeTrajectoryVertical()
    {
        // y movement * -1
    }
}
