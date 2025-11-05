using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private float _damageMultiplier = 1f;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    public void Hit(float baseDamage)
    {
        float finalDamage = baseDamage * _damageMultiplier;
        _enemy.Hit(finalDamage);
    }
}
