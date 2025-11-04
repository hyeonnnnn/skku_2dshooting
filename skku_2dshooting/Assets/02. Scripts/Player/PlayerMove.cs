using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("능력치")]
    public float Speed = 2f;
    public float MaxSpeed = 10f;
    public float MinSpeed = 0.1f;
    public float SpeedIncrement = 0.05f;
    public float SpeedDashAmount = 1.5f;

    [Header("이동범위")]
    public float MaxX = 2;
    public float MinX = -2;
    public float MaxY = 5;
    public float MinY = -5;

    private Vector2 _originPosition;

    void Start()
    {
        _originPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Speed += SpeedIncrement;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Speed -= SpeedIncrement;
        }

        Speed = Mathf.Clamp(Speed, MinSpeed, MaxSpeed);

        float speed = Speed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= SpeedDashAmount;
        }

        if (Input.GetKey(KeyCode.R))
        {
            TranslateToOrigin(speed);
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, v);

        direction.Normalize();

        Vector2 position = transform.position; 

        Vector2 newPosition = position + (direction * speed) * Time.deltaTime;

        if (newPosition.x > MaxX)
        {
            newPosition.x = MinX;
        }
        else if (newPosition.x < MinX)
        {
            newPosition.x = MaxX;
        }
        if (newPosition.y > MaxY)
        {
            newPosition.y = MaxY;
        }
        else if (newPosition.y < MinY)
        {
            newPosition.y = MinY;
        }

        transform.position = newPosition; 
    }

    private void TranslateToOrigin(float speed)
    {
        Vector2 direction = (_originPosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
