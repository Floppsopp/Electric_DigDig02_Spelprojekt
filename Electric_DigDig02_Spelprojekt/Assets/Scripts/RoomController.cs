using UnityEngine;

public class RoomController : MonoBehaviour
{
    public EnemySpawner meleeSpawner;
    public EnemySpawner rangedSpawner;

   
    public int[] meleePerWave = new int[15];
    public int[] rangedPerWave = new int[15];

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WaveManager.Instance.SetActiveRoom(this);
        }
    }

    public void SpawnWave(int effectiveWave)
    {
        Debug.Log("RoomController: meleeSpawner = " + meleeSpawner);
        Debug.Log("RoomController: rangedSpawner = " + rangedSpawner);

        int meleeCount = meleePerWave[effectiveWave - 1];
        int rangedCount = rangedPerWave[effectiveWave - 1];

        Debug.Log("Wave counts → melee: " + meleeCount + " ranged: " + rangedCount);

        if (meleeCount > 0)
            meleeSpawner.SpawnEnemies(meleeCount);

        if (rangedCount > 0)
            rangedSpawner.SpawnEnemies(rangedCount);

        Debug.Log("SpawnWave called for wave " + effectiveWave);
    }

}
