using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    // From 0 to 4 (0% to 100%)
    public Sprite[] img_array = new Sprite[5];
    private Image currImg;

    private void Start()
    {
        currImg = GetComponent<Image>();
    }

    public void ChangeHealth(int index)
    {
        currImg.overrideSprite = img_array[index];
    }
}
