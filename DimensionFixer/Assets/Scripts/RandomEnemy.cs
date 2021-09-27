using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour
{

    public float movementMin = 2;
    public float movementMax = 4;

    public float holdMin = 0.5f;
    public float holdMax = 2;

    private bool walking = false;
    private bool direction = true;
    private float speed = 2;

    public float movement = 2;
    public float hold = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 1) < 0.5) direction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            float walk = Time.deltaTime * speed;
            if (!direction) walk *= -1;

            if (Mathf.Abs(walk) > movement)
            {
                walk = movement;
                if (!direction) walk *= -1;
            }
            this.transform.position = this.transform.position + new Vector3(walk, 0, 0);
            movement -= Mathf.Abs(walk);

            if (movement <= 0)
            {
                direction = !direction;
                walking = false;
                hold = Random.Range(holdMin, holdMax);
            }
        }
        else
        {
            hold -= Time.deltaTime;

            if (hold <= 0)
            {
                walking = true;
                movement = Random.Range(movementMin, movementMax);
            }
        }
    }
}
