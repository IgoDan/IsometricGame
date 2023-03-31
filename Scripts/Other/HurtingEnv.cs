using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtingEnv : MonoBehaviour
{

    public int damageAmount;

    private void OnTriggerStay2D(Collider2D player)
    {
        if(player != null && player.tag == "Player")
        {
            player.GetComponent<CharacterStats>().ChangeHealth(-damageAmount);
        }
    }
}
