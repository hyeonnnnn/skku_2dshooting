using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float _health;

    // 데미지를 입음
    public void TakeDamage(float damage)
    {
        Debug.Log($"Enemy Hit! Damage: {damage}");
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
