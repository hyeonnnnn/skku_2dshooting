using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("이동 속도")]
    private float _currentSpeed;
    private float _startSpeed = 0.01f;
    private float _endSpeed = 0.03f;
    private float _duration = 0.2f;
    private float _accelation;

    [Header("총알 움직임")]
    private float _minX = -1.0f;
    private float _maxX = 1.0f;
    private float _moveStep = 0.01f;
    private float _moveDistance = 0f;
    private bool _isMoveLeft = true;

    private void Start()
    {
        _currentSpeed = _startSpeed;
        _accelation = (_endSpeed - _startSpeed) / _duration;
    }

    private void Update()
    {
        MoveBullet();
        MoveXAxis();
    }

    private void MoveBullet()
    {
        _currentSpeed += _accelation * Time.deltaTime;
        _currentSpeed = Mathf.Min(_currentSpeed, _endSpeed);
        transform.Translate(Vector3.up * _currentSpeed);
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