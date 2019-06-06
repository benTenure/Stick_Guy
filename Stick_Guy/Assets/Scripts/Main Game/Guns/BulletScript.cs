using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed = 10f;
    public float deathCounter = 0.5f;

    // So we can give the player points
    public GameObject player;
    public PlayerInteractions pi;

    [SerializeField]
    private AudioClip hit;
    private AudioSource audio;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pi = player.GetComponent<PlayerInteractions>();
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

        deathCounter -= Time.deltaTime;

        if(deathCounter <= 0)
        {
            BulletObjectPool.Instance.ReturnToPool(this);
        }

        // Actually moves the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            audio.PlayOneShot(hit);

            // Call method to decrement life from enemy
            col.GetComponent<CabinetAIScript>().hurtEnemy();
            col.GetComponent<CabinetAIScript>().speed = 0;

            col.GetComponent<Animator>().SetBool("wasHit", true);

            pi.playerScore += 100;

            // Get rid of the bullet now
            BulletObjectPool.Instance.ReturnToPool(this);
        }
    }

}
