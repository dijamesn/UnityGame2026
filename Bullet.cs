using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float damage = 50f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public LayerMask enemyMask;

    public void Start()
    {
        speed += WaveSpawner.waveIndex;
    }


    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        if (impactEffect != null)
        {
            GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
        }

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, enemyMask);

        foreach (Collider collider in colliders)
        {
            Enemy e = collider.GetComponent<Enemy>();

            if (e == null)
                e = collider.GetComponentInParent<Enemy>();

            if (e != null)
            {
                Damage(e.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        if (enemy == null) return;

        Enemy e = enemy.GetComponent<Enemy>();

        if (e == null)
            e = enemy.GetComponentInParent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}