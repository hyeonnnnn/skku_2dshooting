using UnityEngine;

public class TraceTypeEnemy : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<MoveTraceComponent>();
        gameObject.AddComponent<HealthComponent>();
        gameObject.AddComponent<AttackComponent>();
    }
}
