using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private float _damageMultiplier = 1f;
    private HealthComponent _health;

    private void Start()
    {
        _health = GetComponentInParent<HealthComponent>();
    }

    public void Hit(float baseDamage)
    {
        float finalDamage = baseDamage * _damageMultiplier;
        _health.TakeDamage(finalDamage);
    }
}
