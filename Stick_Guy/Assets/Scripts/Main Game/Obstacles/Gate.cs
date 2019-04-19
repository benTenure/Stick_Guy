using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public EnemySpawnerScript e1;
    public EnemySpawnerScript e2;
    public EnemySpawnerScript e3;
    public EnemySpawnerScript e4;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            e1.gameObject.SetActive(true);
            e2.gameObject.SetActive(true);
            e3.gameObject.SetActive(true);
            e4.gameObject.SetActive(true);
        }
    }
}
