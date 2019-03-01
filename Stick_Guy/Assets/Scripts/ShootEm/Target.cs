using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private const int TARGETS = 3;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {

        print("woo");
        int randomX, randomY;
        int[] coordinatesX = new int[TARGETS];
        int[] coordinatesY = new int[TARGETS];
        for (int i = 0; i < TARGETS; i++)
        {
            randomX = Random.Range(-10, 10);
            foreach(int x in coordinatesX)
            {
                if(x == randomX)
                {
                    randomX += 2;

                }
            }
            randomY = Random.Range(-4, 4);
            foreach (int y in coordinatesY)
            {
                if (y == randomY)
                {
                    randomY += 1;

                }
            }

            Instantiate(prefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
        }
        
    }

}
