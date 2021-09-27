using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAttackSpeed : MonoBehaviour
{
    public ShootingController upgradeShoot;
    public Shoot pinkStyle;
    public float atkSpeedValue = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            upgradeShoot.oldShoot = upgradeShoot.shootPrefab;
            upgradeShoot.shootPrefab = pinkStyle;
            upgradeShoot.attackSpeed -= atkSpeedValue;
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
    }
}
