using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    public static EnemyTracker Instance;

    public int enemiesAlive = 0;
    public WallOpener wallToOpen;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterEnemy()
    {
        enemiesAlive++;
    }

    public void EnemyDied()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            wallToOpen.OpenWall();
        }
    }
}
