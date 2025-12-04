using UnityEngine;
using System.Collections;

public class enemy2Script : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Movement")]
    public float followSpeed = 5f;
    public float rotationSpeed = 5f;
    public float stopDistance = 15f; 

    [Header("Ranged Attack")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootForce = 20f;
    public float attackCooldown = 2f;

    private bool canShoot = true;

    [Header("Health")]
    public float Enemy2Maxhealth = 10f;
    public float Enemy2CurrentHealth;

    void Start()
    {
        Enemy2CurrentHealth = Enemy2Maxhealth;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        float distanceToTarget = direction.magnitude;

        // Rotate toward player
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        // Movement & Shooting logic
        if (distanceToTarget > stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        }
        else
        {
            if (canShoot)
                StartCoroutine(ShootRoutine());
        }

        if (Enemy2CurrentHealth <= 0)
            Enemy2Die();
    }

    IEnumerator ShootRoutine()
    {
        canShoot = false;
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * shootForce, ForceMode.Impulse);

        yield return new WaitForSeconds(attackCooldown);
        canShoot = true;
    }

    public void TakeDamage(float damage)
    {
        Enemy2CurrentHealth -= damage;
        Debug.Log(Enemy2CurrentHealth);
    }

    void Enemy2Die()
    {
        Destroy(gameObject);
    }
}
