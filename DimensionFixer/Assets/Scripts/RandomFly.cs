using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFly : MonoBehaviour
{
    public float accelerationTime = 2f;
    public float maxSpeed = 10f;
    private Vector2 movement;
    private float timeLeft;
    private Rigidbody2D rigidBody;
    private Vector2 startPoint;
    public float range = 5;

    private Vector2 position;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        startPoint = this.transform.position;
    }

    // Update is called once per frame
    

    void Update()
    {
        float step = maxSpeed * Time.deltaTime;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            target = startPoint + Random.insideUnitCircle * 5;
            timeLeft += accelerationTime;

            /*float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            if (this.transform.position.x + randomX < startPoint.x + range && this.transform.position.y + randomY < startPoint.y +range)
            {
                
                //this.transform.position = this.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                rigidBody.velocity = new Vector2(randomX, randomY);
            }
            else
            {
                rigidBody.velocity = new Vector2(startPoint.x, startPoint.y);
            }
            */

            //this.GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(this.transform.position, target.normalized, Time.deltaTime * maxSpeed));
            //this.transform.position = startPoint + Random.insideUnitCircle * 5;
        }
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    void FixedUpdate()
    {
        //this.gameObject.GetComponent<Rigidbody>().AddForce(movement * maxSpeed);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(startPoint, this.range);
    }
}
