using UnityEngine;

public class UltimateCollider : MonoBehaviour
{
    private float _damage = 10000;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitEnemy(collision.gameObject);
    }

    private void HitEnemy(GameObject target)
    {
        if (target.CompareTag("Enemy") == false) return;

        HealthComponent health = target.GetComponent<HealthComponent>();
        
        if (health == null) return;
        health.TakeDamage(_damage);
    }
}
