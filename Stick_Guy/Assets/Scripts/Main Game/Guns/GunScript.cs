using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    [SerializeField]
    private AudioClip shoot;
    private AudioSource audio;

    public bool isFiring;

    public BulletScript bullet;
    public float bulletSpeed;

    public float fireRate;
    private float shotTimer;

    public Transform bulletSpawn;

    private void Start()
    {
        shotTimer = fireRate;
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
		if (isFiring)
        {
            shotTimer -= Time.deltaTime;
                
            if (shotTimer <= 0)
            {
                //NEED TO REPLACE THIS WITH OBJECT POOL
                shotTimer = fireRate;
                BulletScript newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as BulletScript;
                audio.PlayOneShot(shoot);
                newBullet.speed = bulletSpeed;
            }
        }
	}
}
