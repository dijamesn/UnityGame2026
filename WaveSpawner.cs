using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform bossPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    public static int waveIndex = 0;

    public float SpawnRateDecrease = 1f;

    public static int EnemiesAlive = 0;

    public int finalWave = 60;

    private bool levelCompleted = false;
    private bool isSpawning = false;

    void Start()
    {
        waveIndex = 0;
        EnemiesAlive = 0;
        levelCompleted = false;
        isSpawning = false;
    }

    void Update()
    {
        if (levelCompleted)
            return;

        // Don't tick down the countdown while enemies are still alive or a wave is in progress
        if (isSpawning || EnemiesAlive > 0)
        {
            waveCountdownText.text = "0";
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;

        waveIndex++;
        SpawnRateDecrease = SpawnRateDecrease * 0.95f;

        if (waveIndex > 50)
        {
            int bossCount = waveIndex - 50;
            for (int i = 0; i < bossCount; i++)
            {
                SpawnBossEnemies();
                EnemiesAlive++;
                yield return new WaitForSeconds(2f);
            }
        }

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            EnemiesAlive++;
            yield return new WaitForSeconds(0.5f * SpawnRateDecrease);
        }

        isSpawning = false;

        // Wait until all enemies are dead before allowing the next wave to count down
        yield return new WaitUntil(() => EnemiesAlive <= 0);

        if (waveIndex >= finalWave)
        {
            if (!levelCompleted)
            {
                levelCompleted = true;

                GameManager gm = FindObjectOfType<GameManager>();
                if (gm != null)
                {
                    gm.WinLevel();
                }
                else
                {
                    Debug.LogError("GameManager not found in scene when trying to WinLevel().");
                }
            }
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnBossEnemies()
    {
        Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
