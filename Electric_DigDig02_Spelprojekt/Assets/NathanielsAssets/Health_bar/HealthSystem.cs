using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public Image healthImage;
    public Sprite[] healthStates;

    int currentHealth;

    private void Start()
    {
        currentHealth = healthStates.Length - 1;
        healthImage.sprite = healthStates[currentHealth];
    }

    public void TakeDamage()
    {
        if (currentHealth <= 0) return;

        currentHealth--;

        healthImage.sprite = healthStates[currentHealth];

        StartCoroutine(Flash());

        if (currentHealth <= 0)
        {
            Debug.Log("Player Dead");
        }
    }

    IEnumerator Flash()

    {
        healthImage.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        healthImage.color = Color.white;
    }
}






