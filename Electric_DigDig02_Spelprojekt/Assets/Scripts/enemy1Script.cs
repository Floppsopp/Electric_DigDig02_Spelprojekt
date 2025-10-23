using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class enemy1Script : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Movement")]
    public float followSpeed = 5f;
    public float rotationSpeed = 5f;
    public float stopDistance = 2f; 

    [Header("Attack")]
    public bool isAttacking = false; 
    public float attackDuration = 2f; 
    private bool isInRange = false;

    [Header("Health")]
    public float Enemy1Maxhealth = 1f;
    public float Enemy1CurrentHealth;

    [Header("Hitbox")]
    public GameObject Enemy1AttackHitbox;


    private Coroutine attackRoutine;
    private void Start()
    {
        Enemy1CurrentHealth = Enemy1Maxhealth;
        Enemy1AttackHitbox.SetActive(false);
    }
    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f; 
        float distanceToTarget = direction.magnitude;

        
        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

       
        if (!isAttacking)
        {
            if (distanceToTarget > stopDistance)
            {
              
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.position,
                    followSpeed * Time.deltaTime
                );
                isInRange = false;
            }
            else
            {
               
                if (!isInRange)
                {
                    isInRange = true;
                    StartAttack();
                }
            }
        }
        if (Enemy1CurrentHealth == 0)
        {
            Enemy1Die();
        }
    }

    void Enemy1Die()
    {
        Destroy(gameObject);
    }
    void StartAttack()
    {
        if (attackRoutine != null)
            StopCoroutine(attackRoutine);

        attackRoutine = StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;

       
        if (Enemy1AttackHitbox != null)
            Enemy1AttackHitbox.SetActive(true);

       
        yield return new WaitForSeconds(attackDuration);

        if (Enemy1AttackHitbox != null)
            Enemy1AttackHitbox.SetActive(false);


        isAttacking = false;
        isInRange = false;
    }
}
