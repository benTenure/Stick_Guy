using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementp2 : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    private Vector2 direction;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }

    //it moves in the direction
    public void Move()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    //it will move up and down
    private void GetInput()
    {

        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }

    }
}
