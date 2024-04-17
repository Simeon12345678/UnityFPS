using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class rocket : MonoBehaviour
{
    [SerializeField]
    float damage = 400f;

    [SerializeField]
    float speed = 8f;

    float time;

    void Update()
    {
        // moving
        Vector2 movement = new Vector2(0, 1);
        transform.Translate(movement * speed * Time.deltaTime); 

        time += Time.deltaTime;
        if (time > 20)
        {
            Destroy(this.gameObject);
        }
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
