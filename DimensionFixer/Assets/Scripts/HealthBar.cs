using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.currentHP;
        maxHealth = player.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
