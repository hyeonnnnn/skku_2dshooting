using UnityEngine;

public class MoveTraceComponent : MoveComponent
{
    private GameObject _playerObject;

    private void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");
    }

    // 플레이어를 따라 이동
    protected override void Move()
    {
        if (_playerObject != null)
        {
            Vector2 playerPosition = _playerObject.transform.position;
            Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
            transform.Translate(direction * _moveSpeed * Time.deltaTime);
        }
    }
}
