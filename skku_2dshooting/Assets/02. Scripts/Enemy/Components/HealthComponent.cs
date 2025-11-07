using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float _health;
    private ItemDrop _itemDrop;

    private void Awake()
    {
        _itemDrop = GetComponent<ItemDrop>();
    }

    // 데미지를 입음
    public void TakeDamage(float damage)
    {
        Debug.Log($"Enemy Hit! Damage: {damage}");
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Vector2 position = transform.position;

        _itemDrop.TryDropItem(position);

        Destroy(gameObject);
    }

}
