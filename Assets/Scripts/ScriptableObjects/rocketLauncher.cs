using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour
{
    [SerializeField]
    new string name;

    [SerializeField]
    float damage;

    [SerializeField]
    float maxDistance;

    [SerializeField]
    float currentAmmo;

    [SerializeField]
    float magSize;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    Transform muzzle;

    [SerializeField]
    GameObject rocket; // projectile to fire

    float fireRate = 200;
    float reloadTime;
    bool isReloading;
    float timeSinceLastShot;

    // invokes functions which control player input 
    void Start()
    {
        playerShoot.shootInput += Shoot;
        playerShoot.reloadInput += BeginReload;
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    void BeginReload()
    {
        if (!isReloading)
        {
            StartCoroutine(reload());
        }
    }

    IEnumerator reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magSize;

        isReloading = false;
    }

    bool CanShoot() => !isReloading && timeSinceLastShot > 1f / fireRate / 60f;

    // todo
    void onGunShot()
    {
        throw new NotImplementedException();
    }

    void Shoot()
    {
        float delay = Time.deltaTime;
        if (currentAmmo > 0 && delay >= 5)
        {
            if (CanShoot())
            {
                // spawns rocket
                Instantiate(rocket, muzzle.position, Quaternion.identity);
                Destroy(rocket, 40); // destroys rocket after set time

                delay = 0;
                currentAmmo--;
                timeSinceLastShot = 0;
                // onGunShot();
            }
        }
    }
}
