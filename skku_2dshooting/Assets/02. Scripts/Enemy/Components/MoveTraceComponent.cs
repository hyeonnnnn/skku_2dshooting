using UnityEngine;

public class MoveTraceComponent : MoveComponent
{
    private Transform _playerTransform;
    [SerializeField] private float _rotationOffset = 90f;

    private void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        
        if (playerObject != null)
        {
            _playerTransform = playerObject.transform;
        }
    }

    // 플레이어를 따라 이동
    protected override void Move()
    {
        Vector2 direction = Vector2.down;

        if (_playerTransform != null)
        {
            direction = (_playerTransform.position - transform.position).normalized;
        }
            
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector2 newPosition = _playerTransform.position - transform.position;
        float rotationZ = Mathf.Atan2(newPosition.y, newPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ + _rotationOffset);
    }
}
