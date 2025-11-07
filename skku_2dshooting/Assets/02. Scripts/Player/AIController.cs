using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("탐지 및 이동")]
    [SerializeField] private float _detectionRadius = 4f;
    [SerializeField] private float _dangerZoneRadius = 1f;
    [SerializeField] private float _attackDistance = 3f;
    [SerializeField] private float _moveSpeed = 3f;

    private Transform _target;
    private StateManager _stateManager;

    public Transform GetTarget() => _target;
    public float GetDangerZoneRadius() => _dangerZoneRadius;

    private void Awake()
    {
        _stateManager = new StateManager();
        _stateManager.SwitchState(new IdleState(this));
    }

    private void Update()
    {
        _stateManager.Update();
    }

    public void SwitchState(IState newState)
    {
        _stateManager.SwitchState(newState);
    }

    public Transform DetectTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);

        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        // 가장 가까운 적 탐색
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Enemy") == false) continue;

            float distance = Vector2.Distance(transform.position, hit.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = hit.transform;
            }
        }

        _target = closestTarget;
        return _target;
    }

    public void MoveTowardsTarget()
    {
        if(_target == null) return;

        // 적의 정면으로 이동
        Vector2 targetPosition = _target.position + new Vector3(0, -_attackDistance);
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    public void EvadeFromTarget()
    {
        if (_target == null) return;

        // 적으로부터 멀어지기
        Vector2 direction = (transform.position - _target.position).normalized;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
        Gizmos.DrawWireSphere(transform.position, _dangerZoneRadius);
    }

}
