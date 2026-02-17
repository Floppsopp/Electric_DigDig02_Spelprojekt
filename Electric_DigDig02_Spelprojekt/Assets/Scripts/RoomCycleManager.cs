using UnityEngine;

public class RoomCycleManager : MonoBehaviour
{
    public int roomsPerCycle = 15;
    private int roomsVisited = 0;

    public void RoomCompleted()
    {
        roomsVisited++;
        if (roomsVisited >= roomsPerCycle)
        {
            roomsVisited = 0;
            WaveManager.Instance.ResetWaveTriggers();
            Debug.Log("Cycle complete — Triggers reset");
        }
    }
}
