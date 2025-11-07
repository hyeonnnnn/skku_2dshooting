using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("스탯")]
    private float _health = 5;

    public void Hit(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void HealthUp(float healAmount)
    {
        _health += healAmount;
    }
}
