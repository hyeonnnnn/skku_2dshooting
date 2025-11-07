using UnityEngine;

public class MoveLinearComponent : MoveComponent
{
    [Header("이동 방향")]
    [SerializeField] private Vector2 _direction = Vector2.down;

    // 일직선으로 이동
    protected override void Move()
    {
        transform.Translate(_direction.normalized * _moveSpeed * Time.deltaTime);
    }
}
