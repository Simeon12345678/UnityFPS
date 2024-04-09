using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Idamageable
{
    public void ReceiveDMG(float damage);
}

public class DamageAble : MonoBehaviour, Idamageable
{
    [SerializeField]
    float health = 100f;

    public void ReceiveDMG(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("dead");
        }
    }

    void Update()
    {
        
    }
}
