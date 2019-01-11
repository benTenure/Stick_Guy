using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public bool isFiring;

    public BulletScript bullet;
    public float bulletSpeed;

    public float fireRate;
    private float shotTimer;

    public Transform bulletSpawn;

	// Update is called once per frame
	void Update ()
    {
		if (isFiring)
        {
            shotTimer -= Time.deltaTime;

            if (shotTimer <= 0)
            {
                shotTimer = fireRate;
                BulletScript newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as BulletScript;
                newBullet.speed = bulletSpeed;
            }
            else
            {
                shotTimer = 0;
            }
        }
	}
}
