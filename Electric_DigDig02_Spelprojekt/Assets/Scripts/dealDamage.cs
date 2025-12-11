using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    public bool Attacking = false;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Attacking = true;
        }
        else
        {
            Attacking = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetMouseButton(0))
         {
            

            // Compares the tag on collision (Must match Enemy_1)
            if (other.CompareTag("Enemy_1"))
            {
                //Gets component from enemy1Script to be able to deal damage.
                enemy1Script enemy = other.GetComponent<enemy1Script>();
                enemy.TakeDamage(damage);
            }
        }
    }
   
}
