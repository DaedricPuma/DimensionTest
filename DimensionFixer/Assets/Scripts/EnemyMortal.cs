using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMortal : MonoBehaviour
{
    public int hp = 100;
    private int currentHp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.currentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        this.currentHp -= 25;

    }
}
