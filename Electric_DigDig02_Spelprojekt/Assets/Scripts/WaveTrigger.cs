using UnityEngine;

public class WaveTrigger : MonoBehaviour
{
    private bool hasBeenUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenUsed)
        {
            hasBeenUsed = true;
            WaveManager.Instance.TriggerNextWave();

        }
    }

    public void ResetTrigger()
    {
        hasBeenUsed = false;
    }
}

