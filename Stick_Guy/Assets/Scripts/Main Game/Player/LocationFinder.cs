using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationFinder : MonoBehaviour
{
    public Transform player;
    private Transform me;

    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bad for performance? We'll find out eventually...
        me.position = new Vector3(player.position.x, 0f, player.position.z);
    }
}
