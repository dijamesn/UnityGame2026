using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    public float startHealth = 100;
    [HideInInspector]
    public float health;

    public int worth = 50;

    private bool isDead = false;

    public float healthIncrease = 1f;

    public bool isBoss = false;

    public float bossSlowMultiplier = 0.2f;

    void Start()
    {
        health = startHealth;
        startHealth += healthIncrease;
        target = Waypoints.points[0];

        if (isBoss)
        {
            if (WaveSpawner.waveIndex >= 51)
            {
                speed *= bossSlowMultiplier;
            }
            return;
        }

        speed += WaveSpawner.waveIndex;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;
        Debug.Log("Enemy died. Money now: " + PlayerStats.Money);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}