using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Transform player;

    private float timer = 5f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


        //Spawn a new enemy every five seconds
        if (timer <= 0f)
        {
            Vector3 newPos = new Vector3(player.position.x + Random.Range(-5f, -15f), 0f, player.position.z + Random.Range(-10f,10f));
            GameObject e = Instantiate(enemy, newPos, Quaternion.identity);

            // Keep all the enemies spawned under the enemy manager object (looks cleaner in hierarchy)
            e.transform.parent = this.transform;

            //Reset the timer
            timer = 5f;
        }

    }
}
