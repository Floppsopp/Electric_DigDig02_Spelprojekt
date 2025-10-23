using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    
   public int playerMaxHealth = 20;
   public int playerCurrentHealth;
    
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }
    void Update()
    {
        if (playerCurrentHealth == 0)
            Destroy(gameObject);
    }
}
