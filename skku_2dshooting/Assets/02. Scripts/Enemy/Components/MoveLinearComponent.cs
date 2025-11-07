using UnityEngine;

public class MoveLinearComponent : MoveComponent
{
    // 일직선으로 이동
    protected override void Move()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}
