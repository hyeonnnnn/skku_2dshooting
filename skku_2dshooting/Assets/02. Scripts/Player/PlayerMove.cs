using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("능력치")]
    private float _speed = 2f;
    private float _speedDashAmount = 3f;
    private float MaxSpeed = 10f;

    [Header("이동범위")]
    private float _maxX = 2;
    private float _minX = -2;
    private float _maxY = 5;
    private float _minY = -5;

    [Header("시작위치")]
    private Vector2 _originPosition;

    public float Speed => _speed;

    private void Start()
    {
        _originPosition = transform.position;
    }

    private void Update()
    {
        HandleMovement();
    }
    
    private void HandleMovement()
    {
        float finalSpeed = _speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed *= _speedDashAmount;
        }

        if (Input.GetKey(KeyCode.R))
        {
            TranslateToOrigin(finalSpeed);
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, v);

        direction.Normalize();

        Vector2 position = transform.position;

        Vector2 newPosition = position + (direction * finalSpeed) * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, _minX, _maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, _minY, _maxY);

        transform.position = newPosition;
    }

    private void TranslateToOrigin(float speed)
    {
        Vector2 direction = (_originPosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SpeedUp(float value)
    {
        _speed += value;

        _speed = Mathf.Min(_speed, MaxSpeed);
    }
}
