using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("체력 설정")]
    [SerializeField] private float _health;
    
    private bool _isDead = false;
    private ItemDrop _itemDrop;

    private void Awake()
    {
        _itemDrop = GetComponent<ItemDrop>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(_isDead == true) return;
        _isDead = true;

        _itemDrop.TryDropItem(transform.position);
        Destroy(gameObject);
    }
}
