using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerAttack : MonoBehaviour
{

    public GameObject enemy1;
    [SerializeField] float enemyMaxHealth;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetButtonDown("F"))
        {
            anim.SetTrigger(name"attack");
        }

    }
}
