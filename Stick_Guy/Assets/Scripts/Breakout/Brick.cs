using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    private const int NUM_OF_BRICKS = 68;
    private const float X_STARTING_POS = -10f;
    private const float Y_STARTING_POS = 2.5f;
    private const float HORIZONTAL_CHANGE = 1.15f;
    private const float VERTICAL_CHANGE = 1f;
    public GameObject prefab;
	// Use this for initialization
	void Start () {

        float positionX = X_STARTING_POS;
        float positionY = Y_STARTING_POS;

        // create 2d brick board
        for(int i = 1; i <= NUM_OF_BRICKS; i++)
        {
            if(i > 1)
            {
                positionX += HORIZONTAL_CHANGE;
            }

            if(positionX > 10)
            {
                positionY -= VERTICAL_CHANGE;
                positionX = X_STARTING_POS;
            }
            Instantiate(prefab, new Vector3(positionX, positionY, 1f), Quaternion.identity);  
        }

	}
}
