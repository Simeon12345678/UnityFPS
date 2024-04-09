using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class rocket : MonoBehaviour
{
    [SerializeField]
    float damage = 400f;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "damageAble")
        {
            Idamageable damageable = collider.gameObject.GetComponent<Idamageable>();
            damageable?.ReceiveDMG(damage); // deal the damage
            Debug.Log(collider.transform.name);
            Destroy(this.gameObject);
        }
    }
}
