using UnityEngine;
using static CartoonFX.CFXR_Effect;

public class HealthComponent : MonoBehaviour
{
    [Header("체력 설정")]
    [SerializeField] private float _health;

    [Header("이펙트")]
    [SerializeField] private ParticleSystem _deathEffect;

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

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("Damaged");
        if (_health <= 0)
        {
            if (_isDead) return;
            _isDead = true;

            PlayEffect();
            Die();
        }
    }

    private void PlayEffect()
    {
        if (_deathEffect == null) return;
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
    }

    private void Die()
    {
        _itemDrop.TryDropItem(transform.position);
        _cameraShake.Play();
        Destroy(gameObject);
    }
}
