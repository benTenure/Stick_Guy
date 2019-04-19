using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSoda : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            col.gameObject.GetComponent<MovementScript>().moveSpeed /=  2;
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
            col.gameObject.GetComponent<MovementScript>().moveSpeed *= 2;
    }
}
