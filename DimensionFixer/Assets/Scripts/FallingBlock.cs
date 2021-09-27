using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.transform.position = startPosition;
        this.transform.eulerAngles = Vector3.zero;
    }
}
