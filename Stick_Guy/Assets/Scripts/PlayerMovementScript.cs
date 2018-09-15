using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Move () {
        transform.Translate(Vector2.right*moveSpeed*Time.deltaTime);
    }

}
