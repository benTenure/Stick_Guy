using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    private const int NUM_OF_BRICKS = 68;
    private const float BLOCK_WIDTH = .75f;
    private const float BLOCK_HEIGHT = .5f;
    //private const float X_STARTING_POS = -8f;
    //private const float Y_STARTING_POS = 3.5f;
    //private const float HORIZONTAL_CHANGE = 1.15f;
    //private const float VERTICAL_CHANGE = 1f;
    public GameObject prefab; // brick dimensions are .75 by .5
	// Use this for initialization
	void Start () {

        // Right side of skull
        for(float i = 0; i< 2; i += BLOCK_HEIGHT)
        {
            Instantiate(prefab, new Vector3(2.25f, i + 1, 1f), Quaternion.identity);
            if (i != 0)
            {
                Instantiate(prefab, new Vector3(2.25f, -i + 1, 1f), Quaternion.identity);
            }
        }
        // Left side of skull
        for (float i = 0; i < 2; i += BLOCK_HEIGHT)
        {
            Instantiate(prefab, new Vector3(-2.25f, i + 1, 1f), Quaternion.identity);
            if (i != 0) {
                Instantiate(prefab, new Vector3(-2.25f, -i + 1, 1f), Quaternion.identity);
            }
            
        }
        //bottom of skull
        Instantiate(prefab, new Vector3(2.25f - BLOCK_WIDTH, -1, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(-2.25f + BLOCK_WIDTH, -1, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(2.25f - 2 * BLOCK_WIDTH, -1.5f, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(-2.25f + 2 * BLOCK_WIDTH, -1.5f, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(2.25f - 3 * BLOCK_WIDTH, -2, 1f), Quaternion.identity);
        // top of skull
        Instantiate(prefab, new Vector3(2.25f, 3, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(-2.25f, 3, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(2.25f - BLOCK_WIDTH, 3.5f, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(-2.25f + BLOCK_WIDTH, 3.5f, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(2.25f - 2 * BLOCK_WIDTH, 3.5f, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(-2.25f + 2 * BLOCK_WIDTH, 3.5f, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(2.25f - 3 * BLOCK_WIDTH, 4, 1f), Quaternion.identity);

        // eyes
        Instantiate(prefab, new Vector3(.75f, 2, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(-.75f, 2, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(.75f, 1.5f, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(-.75f, 1.5f, 1f), Quaternion.identity);

        // mouth
        Instantiate(prefab, new Vector3(0, 0, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(.75f, -.5f, 1f), Quaternion.identity);
        Instantiate(prefab, new Vector3(-.75f, -.5f, 1f), Quaternion.identity);

        /*
        float positionX = X_STARTING_POS;
        float positionY = Y_STARTING_POS;

        // create 2d brick board
        for(int i = 1; i <= NUM_OF_BRICKS; i++)
        {
            if(i > 1)
            {
                positionX += HORIZONTAL_CHANGE;
            }

            if(positionX > 8.25)
            {
                positionY -= VERTICAL_CHANGE;
                positionX = X_STARTING_POS;
            }
            Instantiate(prefab, new Vector3(positionX, positionY, 1f), Quaternion.identity);  
        }*/

    }
}
