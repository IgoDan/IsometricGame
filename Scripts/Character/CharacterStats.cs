using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector] public int currentHealth;
    public float invincibleTime;
    private bool isInvincible = false;
    float invincibleTimer;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }
    private void FixedUpdate()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }
    public void ChangeHealth(int health)
    {
        if (health < 0)
        {
            if (isInvincible)
                health = 0;
            else
            {
                isInvincible = true;
                invincibleTimer = invincibleTime;
            }
        }
        currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}
