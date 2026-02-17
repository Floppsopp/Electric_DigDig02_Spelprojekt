using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform playerTarget;

    public void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newEnemy = Instantiate(
                enemyPrefab,
                spawnPoint.position,
                Quaternion.Euler(0f, Random.Range(0f, 360f), 0f)
            );

            var enemy1 = newEnemy.GetComponent<enemy1Script>();
            if (enemy1 != null)
            {
                enemy1.target = playerTarget;
                continue;
            }

            var enemy2 = newEnemy.GetComponent<enemy2Script>();
            if (enemy2 != null)
            {
                enemy2.target = playerTarget;
            }
        }
    }
}
