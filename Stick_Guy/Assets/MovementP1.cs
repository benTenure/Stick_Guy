using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementP1 : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    private Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        Move();
    }

    public void Move()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    //it will move up and down
    private void GetInput()
    {

        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

    }
}
