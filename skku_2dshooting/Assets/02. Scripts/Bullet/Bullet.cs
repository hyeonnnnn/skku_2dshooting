using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float StartSpeed = 0.01f;
    public float EndSpeed = 0.03f;
    public float Duration = 0.2f;
    private float _accelation;

    [Header("총알 움직임")]
    private float _minX = -1.0f;
    private float _maxX = 1.0f;
    private float _moveStep = 0.01f;
    private float _moveDistance = 0f;
    private bool _isMoveLeft = true;

    private void Start()
    {
        Speed = StartSpeed;
        _accelation = (EndSpeed - StartSpeed) / Duration;
    }

    private void Update()
    {
        MoveBullet();
        MoveXAxis();
    }

    private void MoveBullet()
    {
        Speed += _accelation * Time.deltaTime;
        Speed = Mathf.Min(Speed, EndSpeed);
        transform.Translate(Vector3.up * Speed);
    }

    private void MoveXAxis()
    {
        Vector2 bulletPosition = transform.localPosition;

        if (_isMoveLeft)
        {
            bulletPosition.x -= _moveStep;
            _moveDistance -= _moveStep;
        }
        else
        {
            bulletPosition.x += _moveStep;
            _moveDistance += _moveStep;
        }

        transform.localPosition = bulletPosition;

        if (_moveDistance < _minX)
        {
            _isMoveLeft = false;
        }
        else if (_moveDistance > _maxX)
        {
            _isMoveLeft = true;
        }
    }
}