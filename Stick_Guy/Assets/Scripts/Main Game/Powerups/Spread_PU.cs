using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread_PU : PowerUp
{
    private float limit;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        SetPowerName("Spread");
        SetTimeLimit(5.0f);

        limit = 5.0f;
        _timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= limit)
        {
            StopPowerUp();

        }

    }
}
