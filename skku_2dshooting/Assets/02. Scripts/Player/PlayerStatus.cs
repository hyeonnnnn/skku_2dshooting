using System.Collections;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("체력")]
    [SerializeField] private float _maxHealth = 5;
    private float _currentHealth;

    [Header("이동 속도")]
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _dashMultiplier = 3f;
    private float _baseSpeed = 2f;

    [Header("공격 스탯")]
    [SerializeField] private float _minFireCoolTime = 0.4f;
    private float _baseFireCoolTime = 0.8f;
    private float _currentFireCoolTime = 0f;

    [Header("피격 이펙트")]
    [SerializeField] private float _hitFlashDuration = 0.1f;
    [SerializeField] private Color _hitFlashColor = Color.red;
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;

    [Header("데미지 이펙트")]
    [SerializeField] private ParticleSystem _damageEffect;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _currentFireCoolTime = _baseFireCoolTime;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = GetComponent<SpriteRenderer>().color;
    }

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    public float BaseSpeed => _baseSpeed;
    public float DashMultiplier => _dashMultiplier;
    public float CurrentFireCoolTime => _currentFireCoolTime;

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        StartCoroutine(FlashHitColor());
        Instantiate(_damageEffect, transform.position, Quaternion.identity);
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

    public void MoveSpeedUp(float value)
    {
        _baseSpeed += value;
        _baseSpeed = Mathf.Min(_baseSpeed, _maxSpeed);
    }

    public void FireCoolTimeDown(float value)
    {
        _baseFireCoolTime -= value; 
        _baseFireCoolTime = Mathf.Max(_baseFireCoolTime, _minFireCoolTime);
    }

    private void Die()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sfx.GAMEOVER);
        SavePlayerScore();
        Destroy(gameObject);
    }

    private void SavePlayerScore()
    {
        ScoreManager.Instance.SaveBestScore();
    }

    private IEnumerator FlashHitColor()
    {
        _spriteRenderer.color = _hitFlashColor;
        yield return new WaitForSeconds(_hitFlashDuration);
        _spriteRenderer.color = _originalColor;
    }
}
