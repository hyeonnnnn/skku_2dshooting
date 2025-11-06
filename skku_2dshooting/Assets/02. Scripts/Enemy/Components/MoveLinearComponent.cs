using UnityEngine;

public class MoveLinearComponent : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    private void Update()
    {
        Move();
    }

    // 일직선으로 이동
    private void Move()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
