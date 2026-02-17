using UnityEngine;

public class RoomController : MonoBehaviour
{
    public EnemySpawner meleeSpawner;
    public EnemySpawner rangedSpawner;

    // Size 15 arrays = wave patterns 1–15
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
        int meleeCount = meleePerWave[effectiveWave - 1];
        int rangedCount = rangedPerWave[effectiveWave - 1];

        if (meleeCount > 0)
            meleeSpawner.SpawnEnemies(meleeCount);

        if (rangedCount > 0)
            rangedSpawner.SpawnEnemies(rangedCount);
    }
}
