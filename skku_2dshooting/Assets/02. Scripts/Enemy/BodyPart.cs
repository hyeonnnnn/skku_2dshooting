using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [Header("피격 데미지 배율")]
    [SerializeField] private float _damageMultiplier = 1f;

    private HealthComponent _health;

    private void Awake()
    {
        _health = GetComponentInParent<HealthComponent>();

        if (_health == null) return;
    }

    public void Hit(float baseDamage)
    {
        if(_health == null) return;
        if (_health.gameObject.activeInHierarchy == false) return;

        float finalDamage = baseDamage * _damageMultiplier;
        _health.TakeDamage(finalDamage);
    }
}
