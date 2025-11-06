using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    private bool hasDealtDamage = false; 
    private enemy1Script enemyParent;

    private void Start()
    {
        enemyParent = GetComponentInParent<enemy1Script>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasDealtDamage && enemyParent != null && enemyParent.isAttacking)
        {
            if (other.CompareTag("Player"))
            {
                playerHealth player = other.GetComponent<playerHealth>();
                if (player != null)
                {
                    player.playerCurrentHealth -= 1;
                    hasDealtDamage = true;
                }
            }
        }
    }

    private void OnEnable()
    {
        hasDealtDamage = false;
    }
}
