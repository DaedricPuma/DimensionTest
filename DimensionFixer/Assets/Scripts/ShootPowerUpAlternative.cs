using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPowerUpAlternative : MonoBehaviour
{
    public Shoot shootPrefab;
    public float time = 3;
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
            collision.gameObject.GetComponent<ShootingController>().shootPrefab = shootPrefab;
            Destroy(gameObject);
        }
    }
}
