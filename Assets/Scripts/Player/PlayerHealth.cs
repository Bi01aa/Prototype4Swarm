using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;

    private bool isDead;

    [SerializeField] FloatingHealthBar healthBar;

    public GameManagerScript gameManager;

    private void Awake()
    {

        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);

    }





    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            
            gameManager.gameOver();
            

        }
    }
}
