using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyControllerScript : MonoBehaviour {

    private Transform enemyHolder;
    public float speed;
    private float timer = 0.0f;

    public Text winText;
    public GameObject shot;
    public float fireRate = 0.7f;

    private MovementScript ms;

	// Use this for initialization
	void Start () {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
        ms = FindObjectOfType<MovementScript>();
	}

    private void Update()
    {
        if (enemyHolder.childCount < 1)
        {
            CancelInvoke();
            winText.enabled = true;

            timer += Time.deltaTime;

            if (timer >= 5.0f) {
                ms.canMove = true;
                SceneManager.UnloadSceneAsync("SpaceInvaders");
            }
        }
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach(Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -7.5 || enemy.position.x > 7.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 1f;
                return;
            }

            if (Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            if (enemy.position.y <= 4)
            {
                GameOverScript.isPlayerDead = true;
                Time.timeScale = 1;
            }
        }

        if (enemyHolder.childCount > 0)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        
    }
}
