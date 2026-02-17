using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    public int currentWave = 0;
    public float spawnDelay = 10f;

    private RoomController activeRoom;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetActiveRoom(RoomController room)
    {
        activeRoom = room;
    }

    public void TriggerNextWave()
    {
        currentWave++;

        int effectiveWave = ((currentWave - 1) % 15) + 1;

        Debug.Log("Wave " + currentWave + " (pattern " + effectiveWave + ")");

        StartCoroutine(DelayedSpawn(effectiveWave));
    }

    private IEnumerator DelayedSpawn(int effectiveWave)
    {
        yield return new WaitForSeconds(spawnDelay);

        if (activeRoom != null)
        {
            activeRoom.SpawnWave(effectiveWave);
        }
    }

    public void ResetWaveTriggers()
    {
        WaveTrigger[] triggers = FindObjectsOfType<WaveTrigger>();
        foreach (var trigger in triggers)
        {
            trigger.ResetTrigger();
        }
    }
}
