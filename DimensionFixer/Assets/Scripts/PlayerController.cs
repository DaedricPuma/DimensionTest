using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float hp = 100f;
    public float health;
    public float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        health = hp;
        currentHP = hp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
