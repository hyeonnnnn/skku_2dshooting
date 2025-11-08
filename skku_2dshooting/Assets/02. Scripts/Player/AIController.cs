using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("탐지 및 이동")]
    [SerializeField] private float _detectionRange = 6.5f;
    [SerializeField] private float _dangerZoneRange = 1.5f;
    [SerializeField] private float _attackDistance = 3f;
    [SerializeField] private float _moveSpeed = 3f;

    private Transform _target;
    private ContactFilter2D _filter;
    private Collider2D[] _hits;
    private const int MaxHits = 10;

    [SerializeField] private float _evadeWidthMin = -2f;
    [SerializeField] private float _eavdeWidthMax = 2f;

    private StateManager _stateManager;

    public Transform GetTarget() => _target;
    public float GetDangerZoneRadius() => _dangerZoneRange;

    private void Awake()
    {
        _stateManager = new StateManager();
        _stateManager.SwitchState(new IdleState(this));

        // Enemy 레이어만 감지하도록 필터 설정
        _filter = new ContactFilter2D();
        _filter.SetLayerMask(LayerMask.GetMask("Enemy"));
        _filter.useTriggers = true;

        _hits = new Collider2D[MaxHits];
    }

    public void UpdateAI()
    {
        _stateManager.Update();
    }

    public void SwitchState(IState newState)
    {
        _stateManager.SwitchState(newState);
    }

    public Transform DetectTarget()
    {
        Physics2D.OverlapCircle(transform.position, _detectionRange, _filter, _hits);

        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        // 가장 가까운 적 탐색
        foreach (Collider2D hit in _hits)
        {
            if (hit == null) continue;
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
        float widthOffset = Random.Range(_evadeWidthMin, _eavdeWidthMax);

        Vector2 selfPosition = (Vector2)transform.position + new Vector2(widthOffset, 0);
        Vector2 targetPosition = _target.position;
        Vector2 direction = (selfPosition - targetPosition).normalized;

        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
        Gizmos.DrawWireSphere(transform.position, _dangerZoneRange);
    }

}
