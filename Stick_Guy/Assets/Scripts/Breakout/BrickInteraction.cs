using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickInteraction : MonoBehaviour {
    int health;
    private const int MAX_HEALTH = 3;

	// Use this for initialization
	void Start () {
        health = MAX_HEALTH;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;
        if (health < 1) {
            gameObject.SetActive(false);
        }
        

    }

}
