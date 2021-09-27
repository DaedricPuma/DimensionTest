using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpike : MonoBehaviour
{
    public float attack = 0.3f;
    public float sustain = 2.0f;
    public float release = 1.0f;
    public float period = 1.0f;

    public float offset = 0.8f;

    private int stage = 0;
    private float tracker = 0;

    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tracker += Time.deltaTime;

        if (stage == 0)
        {
            if (tracker > attack)
            {
                stage = 1;
                tracker -= attack;
            }
            else
            {
                this.transform.position = new Vector3(startPos.x, startPos.y - (offset) * (0.3f - tracker) / 0.3f, 0);
            }
        }

        if (stage == 1)
        {
            if (tracker > sustain)
            {
                stage = 2;
                tracker -= sustain;
            }
        }

        if (stage == 2)
        {
            if (tracker > release)
            {
                stage = 3;
                tracker -= release;
                this.transform.position = new Vector3(startPos.x, startPos.y - offset, 0);
            }
            else
            {
                this.transform.position = new Vector3(startPos.x, startPos.y - (offset) * tracker / release, 0);
            }
        }

        if (stage == 3)
        {
            if (tracker > period)
            {
                stage = 1;
                tracker -= period;
            }
        }
    }
}
