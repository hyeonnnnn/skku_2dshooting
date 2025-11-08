using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [Header("스탯")]
    [SerializeField] private float _maxHealth = 5;
    private float _currentHealth;

    [Header("피격 이펙트")]
    private SpriteRenderer _spriteRenderer;
    private float _hitFlashDuration = 0.1f;
    private Color _originalColor;
    private Color _hitFlashColor = Color.red;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = GetComponent<SpriteRenderer>().color;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        StartCoroutine(FlashHitColor());
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

    private IEnumerator FlashHitColor()
    {
        _spriteRenderer.color = _hitFlashColor;
        yield return new WaitForSeconds(_hitFlashDuration);
        _spriteRenderer.color = _originalColor;

    }
}
