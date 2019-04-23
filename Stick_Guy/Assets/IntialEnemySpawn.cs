using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntialEnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(0, 0, 12);
        GameObject e = Instantiate(enemy, position, Quaternion.identity);

        position = new Vector3(-5, 0, 12);
        e = Instantiate(enemy, position, Quaternion.identity);

        position = new Vector3(5, 0, 12);
        e = Instantiate(enemy, position, Quaternion.identity);
    }
}
