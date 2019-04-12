using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread_Shot_Spawn : MonoBehaviour
{
    private float pressRightTrigger;
    GunScript gunSpread;

    // Start is called before the first frame update
    void Start()
    {
        gunSpread = GetComponent<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // ALWAYS check if trigger is being pushed
        pressRightTrigger = Input.GetAxisRaw("Fire1");

        // Shooting your gun
        if (pressRightTrigger > 0)

            gunSpread.isFiring = true;       

        else

            gunSpread.isFiring = false;
        
            
    }
}
