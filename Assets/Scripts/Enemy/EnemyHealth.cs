using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] protected bool isDead;

    [SerializeField] float health, maxHealth = 3f;

    KillCounter killCounterScript;

    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
    }

  public bool IsDead()
    {
        return isDead;
    }

  

    public void TakeDamage( float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);

        if (health < 0)
        {
            Destroy(gameObject);
            killCounterScript.AddKill();
        }
    }
}
