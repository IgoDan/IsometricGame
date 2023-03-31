using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    

    public GameObject deathEffect;
    public bool isRanged;

    public float enemySpeed;
    public int maxHealth;
    public int enemyDamage;
    int currentHealth;

    public HealthBar healthBar;
    public AIPath aiPath;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    private void FixedUpdate()
    {       
        Vector2 vel = new Vector2(aiPath.desiredVelocity.x, aiPath.desiredVelocity.y);
        FindObjectOfType<EnemyAnimator>().EnemyDirection(vel);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionStay2D(Collision2D hitInfo)
    {
        if(hitInfo.collider.tag == "Player")
        {
            FindObjectOfType<CharacterStats>().ChangeHealth(-enemyDamage);
        }
    }

}
