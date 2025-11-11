using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("체력 설정")]
    [SerializeField] private float _health;

    [Header("이펙트")]
    [SerializeField] private ParticleSystem _deathEffect;

    private bool _isDead = false;
    private ItemDrop _itemDrop;

    private Animator _animator;


    private void Awake()
    {
        _itemDrop = GetComponent<ItemDrop>();
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("Damaged");
        if (_health <= 0)
        {
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
        if(_isDead == true) return;
        _isDead = true;

        _itemDrop.TryDropItem(transform.position);
        Destroy(gameObject);
    }
}
