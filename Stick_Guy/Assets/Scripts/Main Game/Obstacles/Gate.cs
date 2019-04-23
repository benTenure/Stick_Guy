using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject e1;
    public GameObject e2;
    public GameObject e3;
    public GameObject e4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            e1.gameObject.SetActive(true);
            e2.gameObject.SetActive(true);
            e3.gameObject.SetActive(true);
            e4.gameObject.SetActive(true);
        } 
    }    
}
