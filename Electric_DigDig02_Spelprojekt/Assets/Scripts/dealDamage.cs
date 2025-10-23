using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamage : MonoBehaviour
{
    [SerializeField] private float damage;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy_1"))
        {
            enemy1Script enemy = other.GetComponent<enemy1Script>();
            enemy.TakeDamage(damage);
        }
    }
   
}
