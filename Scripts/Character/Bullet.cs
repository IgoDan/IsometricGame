using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float lifeRemaning;
    public int amountOfDamage;
    public bool hurtMainCharacter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (lifeRemaning > 0)
            lifeRemaning -= Time.deltaTime;
        else
            Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.tag);
        
        if (hurtMainCharacter)
        {
            Destroy(gameObject);
        }
        else
        {
            if (hitInfo.tag == "Enemy")
            {
                hitInfo.GetComponent<Enemy>().TakeDamage(amountOfDamage);
                Destroy(gameObject);
            }
            else if (hitInfo.tag != "Player" && !hitInfo.isTrigger)
                Destroy(gameObject);
        }
        
    }
   
     
} 
