using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour
{
    [Header("체력 설정")]
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth = 150;

    [Header("이펙트")]
    [SerializeField] private ParticleSystem _deathEffect;

    [Header("점수")]
    [SerializeField] private int _score;

    [Header("피격 이펙트")]
    [SerializeField] private float _hitFlashDuration = 0.1f;
    [SerializeField] private Color _hitFlashColor = Color.red;
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;

    private bool _isDead = false;
    private ItemDrop _itemDrop;
    private CameraShake _cameraShake;


    private void Awake()
    {
        _itemDrop = GetComponent<ItemDrop>();
        _cameraShake  = Camera.main.GetComponent<CameraShake>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentHealth = _maxHealth;
        _spriteRenderer.color = _originalColor;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            if (_isDead) return;
            _isDead = true;

            PlayDeathEffect();
            Die();
            return;
        }
        StartCoroutine(FlashHitColor());
    }

    private void PlayDeathEffect()
    {
        if (_deathEffect == null) return;
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
    }

    private void Die()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sfx.ENEMYEXPLOSION);
        ScoreManager.Instance.AddScore(_score);

        _itemDrop.TryDropItem(transform.position);
        _cameraShake.Play();

        gameObject.SetActive(false);
    }

    private IEnumerator FlashHitColor()
    {
        _spriteRenderer.color = _hitFlashColor;
        yield return new WaitForSeconds(_hitFlashDuration);
        _spriteRenderer.color = _originalColor;
    }
}
