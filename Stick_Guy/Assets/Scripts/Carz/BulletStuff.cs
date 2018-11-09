using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStuff : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.up * speed;
	}


    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.name);
        Destroy(gameObject);
    }

}
