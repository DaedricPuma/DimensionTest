using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPowerUp : MonoBehaviour
{
    public Shoot skinPrefab;
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
            Instantiate(skinPrefab).transform.parent = collision.gameObject.transform;
            Destroy(gameObject);
        }
    }
}
