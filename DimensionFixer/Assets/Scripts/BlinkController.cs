using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkController : MonoBehaviour
{
    public float period = 0.3f;
    public float max = 0.8f;
    public float min = 0.3f;

    public bool blinking = false;

    private SpriteRenderer sprite;
    private Color color;

    private float tracker = 0;
    private bool on = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (blinking)
        {
            tracker += Time.deltaTime;

            if (tracker > period)
            {
                tracker -= period;
                on = !on;

                if (on) color.a = max;
                else color.a = min;

                sprite.color = color;
            }
        }
    }

    void StopThenOn()
    {
        blinking = false;
        color.a = 1.0f;
        sprite.color = color;
    }

    public void BlinkThenOn(float seconds)
    {
        blinking = true;
        Invoke("StopThenOn", seconds);
    }
}
