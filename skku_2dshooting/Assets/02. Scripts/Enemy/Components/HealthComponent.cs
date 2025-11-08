using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("체력 설정")]
    [SerializeField] private float _health;
    
    private ItemDrop _itemDrop;

    private void Awake()
    {
        _itemDrop = GetComponent<ItemDrop>();
    }

    // 데미지를 입음
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
        _itemDrop.TryDropItem(transform.position);
        Destroy(gameObject);
    }

}
