using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    void ChangeHit()
    {
        this.GetComponent<Animator>().SetBool("wasHit", false);
        this.GetComponent<CabinetAIScript>().speed = 2;
    }
}
