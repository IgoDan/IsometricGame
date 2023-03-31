using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitScript : MonoBehaviour
{
    public int healingAmount;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            FindObjectOfType<CharacterStats>().ChangeHealth(healingAmount);
            Destroy(gameObject);
        }
    }
}