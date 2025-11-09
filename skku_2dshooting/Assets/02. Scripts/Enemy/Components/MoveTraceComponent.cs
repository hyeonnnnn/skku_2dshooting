using UnityEngine;

public class MoveTraceComponent : MoveComponent
{
    private Transform _playerTransform;

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
    }
}
