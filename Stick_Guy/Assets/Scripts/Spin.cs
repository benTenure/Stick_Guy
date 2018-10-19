using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public float speed = 100;
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.up, speed * Time.deltaTime);

	}
}
