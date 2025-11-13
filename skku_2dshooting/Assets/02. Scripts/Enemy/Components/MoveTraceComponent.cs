using UnityEngine;

public class MoveTraceComponent : MoveComponent
{
    private Transform _playerTransform;
    Vector2 direction;
    [SerializeField] private float _rotationOffset = 90f;


    private void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        
        if (playerObject != null)
        {
            _playerTransform = playerObject.transform;
        }
    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        direction = Vector2.down;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // 플레이어를 따라 이동
    protected override void Move()
    {
        direction = Vector2.down;

        if (_playerTransform != null)
        {
            direction = (_playerTransform.position - transform.position).normalized;
            LookAtPlayer();
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        transform.Translate(direction * _moveSpeed * Time.deltaTime);
        
    }

    private void LookAtPlayer()
    {
        Vector2 newPosition = _playerTransform.position - transform.position;
        float rotationZ = Mathf.Atan2(newPosition.y, newPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ + _rotationOffset);
    }
}
