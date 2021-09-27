using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    public Vector2 speed;
    public PlayerController player;
    public GameObject playerGO;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = this.transform.position + (Vector3)speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            //Destroy(gameObject);
            GetComponent<Animator>().SetInteger("Hit", 1);
            speed = new Vector2(0, 0);
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TakeHit();
        }

        if (collision.gameObject.CompareTag("Player") && playerGO.GetComponent<BlinkController>().blinking == false)
        {
            player.currentHP -= 10f;
            //Destroy(gameObject);
            GetComponent<Animator>().SetInteger("Hit", 1);
            speed = new Vector2(0, 0);
            playerGO.GetComponent<BlinkController>().BlinkThenOn(3);
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TakeHit();
        }

        if (collision.gameObject.CompareTag("Player") && playerGO.GetComponent<BlinkController>().blinking == true)
        {
            
            //Destroy(gameObject);
            GetComponent<Animator>().SetInteger("Hit", 1);
            speed = new Vector2(0, 0);
            
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TakeHit();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            GetComponent<Animator>().SetInteger("Hit", 1);
            speed = new Vector2(0, 0);
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TakeHit();
        }

    }
    public void SetDirection(Vector2 direction, float speed)
    {
        this.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void Destroy (string message)
    {
        if (message.Equals("ExplodeEnd"))
        {
            Destroy(gameObject);
        }
    }

}
