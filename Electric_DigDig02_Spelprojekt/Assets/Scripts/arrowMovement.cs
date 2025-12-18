using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 15f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy_2"))
            return;

        if (other.CompareTag("Player"))
        {
            playerHealth player = other.GetComponent<playerHealth>();
            if (player != null)
            {
                player.playerCurrentHealth -= 1;
            }
            Destroy(gameObject);
        }


    }
}
