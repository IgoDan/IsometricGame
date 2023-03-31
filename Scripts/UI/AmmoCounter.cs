using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{

    public Text counter;
    public GameObject player;


    private void Update()
    {
        Weapon weapon = player.GetComponent<Weapon>();
        counter.text = weapon.currentAmmo + "/" + weapon.ammoInStock;
    }
}
