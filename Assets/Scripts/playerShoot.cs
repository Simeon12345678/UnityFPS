using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{

    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField]
    KeyCode reloadKey;

    void Update()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            shootInput?.Invoke();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            reloadInput?.Invoke();
        }
    }
}
