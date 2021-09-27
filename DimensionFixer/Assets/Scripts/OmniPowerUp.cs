using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniPowerUp : MonoBehaviour
{
    public int shoots = 1;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ShootingController>().enabled = false;

            OmniShootController omni = collision.gameObject.AddComponent<OmniShootController>();
            omni.speed = 10;
            omni.setShoots(shoots);

            collision.gameObject.GetComponent<OmniShootController>().enabled = true;
            collision.gameObject.GetComponent<OmniShootController>().setShoots(shoots);
            Destroy(gameObject);
            //Invoke("CancelPowerUp", time);
        }
    }
}
