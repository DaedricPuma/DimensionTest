using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShotSpeed : Collectables
{
    public ShootingController upgradeShoot;
    public Shoot greenStyle;
    public float speedValue = 10.0f;
    
    //public float duration = 5.0f;
    //public float tracker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (upgradeShoot.shootPrefab == greenStyle)
        {
            tracker = duration;
            if (tracker > 0)
            {
                tracker -= Time.deltaTime;
            }
            if (tracker == 0)
            {
                upgradeShoot.shootPrefab = upgradeShoot.oldShoot;
            }
            if (tracker < 1)
            {
                tracker = 0;
            }
        }*/
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            upgradeShoot.oldShoot = upgradeShoot.shootPrefab;
            upgradeShoot.shootPrefab = greenStyle;
            upgradeShoot.speed += speedValue;
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
    }
}
