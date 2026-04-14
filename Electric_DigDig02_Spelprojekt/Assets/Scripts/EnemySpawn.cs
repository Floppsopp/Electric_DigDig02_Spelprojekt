using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform playerTarget;

    public void SpawnEnemies(int amount)
    {
        Debug.Log("EnemySpawner on " + gameObject.name + " is trying to spawn " + amount + " enemies. Prefab: " + enemyPrefab);
        for (int i = 0; i < amount; i++)
        {
            GameObject newEnemy = Instantiate(
                enemyPrefab,
                spawnPoint.position,
                Quaternion.Euler(0f, Random.Range(0f, 360f), 0f)
            );

            float healthMultiplier = Mathf.Pow(1.02f, WaveManager.Instance.currentWave);


            var enemy1 = newEnemy.GetComponent<enemy1Script>();
            if (enemy1 != null)
            {
                enemy1.SetHealth(enemy1.Enemy1Maxhealth * healthMultiplier);
                enemy1.target = playerTarget;
                continue;
            }

            var enemy2 = newEnemy.GetComponent<enemy2Script>();
            if (enemy2 != null)
            {
                enemy2.SetHealth(enemy2.Enemy2Maxhealth * healthMultiplier);
                enemy2.target = playerTarget;
            }
        }
    }
}
