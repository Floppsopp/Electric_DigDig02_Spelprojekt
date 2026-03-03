using UnityEngine;
using TMPro;

public class WaveDisplay : MonoBehaviour
{
    public TextMeshProUGUI currentWaveText;
    public TextMeshProUGUI highestWaveText;

    void Update()
    {
        currentWaveText.text = "Wave: " + WaveManager.Instance.currentWave;
        highestWaveText.text = "Highscore: " + WaveManager.Instance.highestWave;
    }
}
