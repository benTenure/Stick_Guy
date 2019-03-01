using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingTextScript : MonoBehaviour
{
    public float FadeRate;
    private float targetAlpha;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
        targetAlpha = img.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        Color currColor = img.color;
        float alphaDiff = Mathf.Abs(currColor.a - targetAlpha);

        // Alpha's aren't equal? Make them.
        if (alphaDiff > 0.0001f)
        {
            currColor.a = Mathf.Lerp(currColor.a, targetAlpha, FadeRate * Time.deltaTime);
            img.color = currColor;
        }
    }

    public void FadeIn()
    {
        targetAlpha = 1.0f;
    }

    public void FadeOut()
    {
        targetAlpha = 0.0f;
    }
}
