using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickInteraction : MonoBehaviour {
    int health;
	// Use this for initialization
	void Start () {
        health = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;
        if (health < 1) {
            gameObject.SetActive(false);
        }
        

    }

}
