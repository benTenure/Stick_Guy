using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    [SerializeField]
    private AudioClip shoot;
    private AudioSource audio;

    public bool isFiring;

    public float fireRate;
    private float shotTimer;

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
                Fire();
            }
        }
	}

    private void Fire ()
    {
        shotTimer = fireRate;
        audio.PlayOneShot(shoot);
        var shot = BulletObjectPool.Instance.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
}
