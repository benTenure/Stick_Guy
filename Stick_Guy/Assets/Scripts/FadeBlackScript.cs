using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlackScript : MonoBehaviour
{
    public float FadeRate;
    private float targetAlpha;
    private SpriteRenderer sr;
    private Color col;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        col = this.sr.color;
        targetAlpha = this.sr.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        Color currColor = col;
        float alphaDiff = Mathf.Abs(currColor.a - targetAlpha);

        // Alpha's aren't equal? Make them.
        if (alphaDiff > 0.0001f)
        {
            currColor.a = Mathf.Lerp(currColor.a, targetAlpha, FadeRate * Time.deltaTime);
            col = currColor;
            Debug.Log("Current alpha:" + col.a);
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
