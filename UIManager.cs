using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text moneyText;
    public Text livesText;
    public Text waveText;

    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
        livesText.text = "Lives: " + PlayerStats.Lives.ToString();
        waveText.text = "Wave " + WaveSpawner.waveIndex.ToString();
    }
}