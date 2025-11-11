using UnityEngine;

public class UltimateCollider : MonoBehaviour
{
    [SerializeField] private float _damage = 10000;
    private const string EnemyTag = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitEnemy(collision.gameObject);
    }

    private void HitEnemy(GameObject target)
    {
        if (!target.CompareTag(EnemyTag))
            return;

        if (target.TryGetComponent<HealthComponent>(out var health))
        {
            health.TakeDamage(_damage);
        }
    }
}
