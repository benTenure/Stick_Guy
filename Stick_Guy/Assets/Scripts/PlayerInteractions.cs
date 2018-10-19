using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    public GameObject prompt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.name == "Arcade Trigger")
        {
            Debug.Log("We found a " + col.gameObject.name);
            prompt.gameObject.SetActive(true);

        }

    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("Come back again sooN!");

        if (col.gameObject.name == "Arcade Trigger")
        {
            prompt.gameObject.SetActive(false);
        }
    }
}
