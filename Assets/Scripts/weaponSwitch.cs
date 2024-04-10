using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour
{
    [SerializeField]
    Transform[] weapons;

    [SerializeField]
    KeyCode[] keys;

    [SerializeField]
    float timeToSwitch = 10f;

    int weaponSelected;
    float timeSinceLastSwitch;

    void Start()
    {
        SetWeapons();
        Select(weaponSelected);


        timeSinceLastSwitch = 0f;
    }

    void Update()
    {
        int previous = weaponSelected;

        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]) && timeSinceLastSwitch >= timeToSwitch)
            {
                weaponSelected = i;
            }    
        }

        if (previous != weaponSelected)
        {
            Select(weaponSelected);
        }

        timeSinceLastSwitch += Time.deltaTime;
    }

    void SetWeapons()
    {
        weapons = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i);
        }

        if (keys == null)
        {
            keys = new KeyCode[weapons.Length];
        }
    }

    void Select(int weaponSelected)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == weaponSelected);

        }

        timeSinceLastSwitch = 0f;
        onWeaponSelect();
    }

    void onWeaponSelect()
    {
        Debug.Log("selected a new weapon");
    }

}
