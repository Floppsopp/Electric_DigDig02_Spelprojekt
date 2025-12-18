using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform playerTarget;







    private void SpawnEnemies()
    {
        GameObject newEnemy = Instantiate(
            enemyPrefab,
            spawnPoint.position,
            Quaternion.Euler(0f, Random.Range(0f, 360f), 0f)
        );


        newEnemy.GetComponent<enemy2Script>().target = playerTarget;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnEnemies();
        }
    }
}
