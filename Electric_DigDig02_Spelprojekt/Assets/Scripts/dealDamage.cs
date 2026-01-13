using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    public bool Attacking = false;

    void Update()
    {
        if(Input.GetMouseButton(0)) // Checks if player is pressing mouse0 (Left Click) and sets bool to true or false, depending on if it's pressed or not.
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
        if (Input.GetMouseButton(0)) // Checks if mouse0 (Left Click) is pressed
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
