using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour
{
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
    private void Start()
    {
        playerShoot.shootInput += ShootRocket;
        playerShoot.reloadInput += BeginReload;
    }

    private void Update()
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

    private bool CanShoot() => !isReloading && timeSinceLastShot > 1f / fireRate / 60f;

    // todo
    void onGunShot()
    {
        throw new NotImplementedException();
    }

    private void ShootRocket()
    {
        Debug.Log("made it here");
        // float delay = Time.deltaTime;
        if (currentAmmo > 0)
        {
            if (CanShoot())
            {
                // spawns rocket
                Instantiate(rocket, muzzle.transform.position, Quaternion.identity);

                currentAmmo--;
                timeSinceLastShot = 0;
                // onGunShot();
            }
        }
    }
}
