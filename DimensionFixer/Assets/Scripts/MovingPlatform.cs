using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float dirX, moveSpeed = 3f;
    bool moveRight = true;
    private Vector2 startPos;
    public float range = 4f;

    private void Start()
    {
        startPos = this.transform.position;
    }
    private void Update()
    {
        if (transform.position.x > startPos.x + range)
        {
            moveRight = false;
        }
        if (transform.position.x < startPos.x -range)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

}
