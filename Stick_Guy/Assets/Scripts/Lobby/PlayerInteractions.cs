using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    public GameObject prompt_L;
    public GameObject prompt_M;
    public GameObject prompt_R;

    private void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.name == "L Arcade Trigger")
        {
            //Debug.Log("We found a " + col.gameObject.name);
            prompt_L.gameObject.SetActive(true);
            //prompt = col.gameObject.transform.Find("E Key");

        }
        if (col.gameObject.name == "M Arcade Trigger")
        {
            prompt_M.gameObject.SetActive(true);
        }
        if (col.gameObject.name == "R Arcade Trigger")
        {
            prompt_R.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("Come back again sooN!");

        if (col.gameObject.name == "L Arcade Trigger")
        {
            prompt_L.gameObject.SetActive(false);
        }
        if (col.gameObject.name == "M Arcade Trigger")
        {
            prompt_M.gameObject.SetActive(false);
        }
        if (col.gameObject.name == "R Arcade Trigger")
        {
            prompt_R.gameObject.SetActive(false);
        }
    }
}
