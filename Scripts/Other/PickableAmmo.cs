using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableAmmo : MonoBehaviour
{
    public int ammoQuantity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Weapon weapon = other.GetComponent<Weapon>();

        if(weapon != null)
        {
            weapon.ChangeAmmo(ammoQuantity);
            Destroy(gameObject);
        }
    }


}
