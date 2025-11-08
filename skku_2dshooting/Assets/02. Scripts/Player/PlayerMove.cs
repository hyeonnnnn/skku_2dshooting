using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("능력치")]
    private float _speed = 2f;
    private float _dashMultiplier = 3f;
    private float _maxSpeed = 10f;

    [Header("시작위치")]
    private Vector2 _originPosition;

    private void Start()
    {
        _originPosition = transform.position;
    }

    public void HandleMovement()
    {
        float finalSpeed = _speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed *= _dashMultiplier;
        }
        if (Input.GetKey(KeyCode.R))
        {
            TranslateToOrigin(finalSpeed);
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, v).normalized;
        Vector2 newPosition = (Vector2)transform.position + (direction * finalSpeed) * Time.deltaTime;

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
        _speed = Mathf.Min(_speed, _maxSpeed);
    }
}
