using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarzGun : MonoBehaviour {

    // Use this for initialization
    public Transform firePoint;
    public GameObject bulletPrefab;

	// Update is called once per frame
    void Update () {

        //get input key to fire
        if(Input.GetKeyDown(KeyCode.G)){
            Shoot();
        }
    }

    void Shoot(){

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
