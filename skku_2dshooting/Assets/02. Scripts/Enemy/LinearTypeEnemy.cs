using UnityEngine;

public class LinearTypeEnemy : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<MoveLinearComponent>();
        gameObject.AddComponent<HealthComponent>();
        gameObject.AddComponent<AttackComponent>();
    }
}
