using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public float StartingHP;
    public float currentHP { get; private set; }
    public event EventHandler playerDeath;
    public Image healthBar;

    private void Awake()
    {
        currentHP = StartingHP;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(StartingHP / currentHP, 0, 1);
    }

private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            currentHP -= MeleeEnemy._damage;
        }
        if(currentHP <= 0)
        {
            playerDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Toxic"))
        {
            playerDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
    
}
