using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("스탯")]
    [SerializeField] private float _maxHealth = 5;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Hit(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void HealthUp(float healAmount)
    {
        _currentHealth += healAmount;
        _currentHealth = Mathf.Min(_maxHealth, _currentHealth);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
