using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //
    // Variables every power up will need
    //

    // Length of the power up
    [SerializeField]
    private float timeLimit;

    // How long the power up has been active;
    [SerializeField]
    private float timer = 0f;

    // The name of the power up, for picking up
    [SerializeField]
    private string powerName;

    // public particle FX for each power up?
    // we'll see...

    //
    // Functions every power up will need
    //

    public void StartPowerUp()
    {
        this.gameObject.SetActive(true);
    }

    // When timer ends, we will call this to make disable the power up
    public void StopPowerUp()
    {
        this.gameObject.SetActive(false);
    }

    // If another power up of the same type is picked up, restart the timer
    public void ExtendPowerUp()
    {
        // Timers will count UP to the time limit, so this resets it
        timer = 0;
    }

    // Getters
    public float GetTimeLimit()
    {
        return timeLimit;
    }

    public float GetTimer()
    {
        return timer;
    }

    public string GetPowerName()
    {
        return powerName;
    }

    // Setters
    public void SetTimeLimit(float p)
    {
        timeLimit = p;
    }

    public void SetTimer(float p)
    {
        timer = p;
    }

    public void SetPowerName(string p)
    {
        powerName = p;
    }
}