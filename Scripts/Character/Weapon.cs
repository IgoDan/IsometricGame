using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public ReloadBar reloadBar;

    public float bulletSpeed;
  
    public int magCap;

    [HideInInspector] public int ammoInStock;
    [HideInInspector] public int currentAmmo;

    [HideInInspector]public bool isShooting;
    [HideInInspector] public int shootingDirection;
    public float shootingDelayTime;
    private float shootingDelayTimer;
    

    public float reloadTime;
    private bool isReloading = false;
    private float reloadTimer;

    private void Start()
    {
        currentAmmo = magCap;
        ammoInStock = magCap *5;
    }
    void Update()
    {
        
        if (!isReloading)
        {
            if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
            {
                
                currentAmmo -= 1;
                isShooting = true;
                shootingDelayTimer = shootingDelayTime;
                shootingDirection = this.GetComponent<CharacterDirection>().MouseToIndex();
                Shoot();
                //GetComponent<ReloadBar>().StartReloadBar(shootingDelayTime);
            }

            
        }

        if (Input.GetKeyDown("r") && reloadTimer == 0)
        {
            reloadTimer = reloadTime;
            isReloading = true;
            reloadBar.GetComponent<ReloadBar>().StartReloadBar(reloadTime);
        }

        if (isReloading)
        {
            reloadTimer -= Time.deltaTime;
            reloadBar.GetComponent<ReloadBar>().UpdateReloadBar(Time.deltaTime);
            //GetComponent<ReloadBar>().UpdateReloadBar(Time.deltaTime);
            //Debug.Log(reloadTimer);
            if (reloadTimer < 0)
            {
                isReloading = false;
                reloadTimer = 0;
                Reload();
            }
        }


    }

    private void FixedUpdate()
    {
        

        if (isShooting)
        {
            
            shootingDelayTimer -= Time.deltaTime;
            if (shootingDelayTimer < 0)
                isShooting = false;
        }
    }

    void Shoot()
    {
        Vector2 direction = GetComponent<CharacterDirection>().MouseDirection();
        direction.Normalize();
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    void Reload()
    {
        int reloadSize = magCap - currentAmmo;
        if (reloadSize > ammoInStock)
            reloadSize = ammoInStock;
        ChangeAmmo(-reloadSize);
        currentAmmo += reloadSize;

    }

    public void ChangeAmmo(int ammo)
    {
        int newCurrentAmmo = ammoInStock + ammo;
        ammoInStock = Mathf.Max(newCurrentAmmo, 0);
    }
}
