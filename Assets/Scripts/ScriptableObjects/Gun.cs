using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Gun : MonoBehaviour
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

    float fireRate = 10;
    float reloadTime;
    bool isReloading;
    float timeSinceLastShot;

    void Start()
    {
        playerShoot.shootInput += Shoot;
        playerShoot.reloadInput += BeginReload;
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(muzzle.position, muzzle.forward);
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
        if (currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hit, maxDistance))
                {
                    Idamageable damageable = hit.transform.GetComponent<Idamageable>(); // find target that can be damaged
                    damageable?.ReceiveDMG(damage); // deal the damage
                    Debug.Log(hit.transform.name);
                }

                currentAmmo--;
                timeSinceLastShot = 0;
                // onGunShot();
            }
        }
    }
}
