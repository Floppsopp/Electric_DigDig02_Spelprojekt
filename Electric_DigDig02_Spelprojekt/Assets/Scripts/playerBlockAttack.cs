using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBlockAttack : MonoBehaviour
{
   
    public bool isBlocking = false; // Checks if player is blocking or not.
    public int damageReduction = 1; // Reduces damage by 80%
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isBlocking = true;
        }
        else
        {
            isBlocking = false;
        }

    }

    public void takeDamage(int amount)
    {
        if(isBlocking)
        {
            amount *= (1 - damageReduction); // Damage reduction
            Debug.Log("Attack blocked!");
        }
        playerHealth playerHealth = GetComponent<playerHealth>();
        playerHealth.playerCurrentHealth -= amount;
    }
}
