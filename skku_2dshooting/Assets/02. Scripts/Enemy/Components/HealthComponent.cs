using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("체력 설정")]
    [SerializeField] private float _health;

    [Header("이펙트")]
    [SerializeField] private ParticleSystem _deathEffect;

    [Header("점수")]
    [SerializeField] private int _score;

    private bool _isDead = false;
    private ItemDrop _itemDrop;
    private CameraShake _cameraShake;

    private Animator _animator;

    private ScoreManager scoreManager;


    private void Awake()
    {
        _itemDrop = GetComponent<ItemDrop>();
        _animator = GetComponent<Animator>();
        _cameraShake  = Camera.main.GetComponent<CameraShake>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("Damaged");
        if (_health <= 0)
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
        AudioManager.instance.PlaySFX(AudioManager.Sfx.ENEMYEXPLOSION);

        _itemDrop.TryDropItem(transform.position);
        _cameraShake.Play();

        scoreManager?.AddScore(_score);

        Destroy(gameObject);
    }
}
