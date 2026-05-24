using UnityEngine;

public class BossSpeedController : MonoBehaviour
{
    public static BossSpeedController Instance;

    [Tooltip("Boss speed multiplier before wave 51")]
    public float normalMultiplier = 1f;

    [Tooltip("Boss speed multiplier from wave 51 onwards (e.g. 0.5 = half speed)")]
    public float slowMultiplier = 0.5f;

    private bool slowEnabled = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void EnableSlowBoss()
    {
        slowEnabled = true;
    }

    public float GetBossSpeedMultiplier()
    {
        return slowEnabled ? slowMultiplier : normalMultiplier;
    }
}