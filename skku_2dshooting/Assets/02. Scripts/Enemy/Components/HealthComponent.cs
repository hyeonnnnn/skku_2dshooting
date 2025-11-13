using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("체력 설정")]
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth = 150;

    [Header("이펙트")]
    [SerializeField] private ParticleSystem _deathEffect;

    [Header("점수")]
    [SerializeField] private int _score;

    private bool _isDead = false;
    private ItemDrop _itemDrop;
    private CameraShake _cameraShake;

    private Animator _animator;


    private void Awake()
    {
        _itemDrop = GetComponent<ItemDrop>();
        _animator = GetComponent<Animator>();
        _cameraShake  = Camera.main.GetComponent<CameraShake>();
    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _animator.SetTrigger("Damaged");
        if (_currentHealth <= 0)
        {
            if (_isDead) return;
            _isDead = true;

            PlayDeathEffect();
            Die();
        }
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
        _animator.ResetTrigger("Damaged");

        gameObject.SetActive(false);
    }
}
