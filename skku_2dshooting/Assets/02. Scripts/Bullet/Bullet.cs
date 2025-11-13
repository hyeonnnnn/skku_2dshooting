using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("이동 속도")]
    [SerializeField] private float _startSpeed = 0.02f;
    [SerializeField] private float _endSpeed = 0.03f;
    [SerializeField] private float _duration = 0.5f;
    private float _currentSpeed;
    private float _acceleration;

    [Header("스탯")]
    public float Damage;

    private void OnEnable()
    {
        Init();
    }

    private void Update()
    {
        Move();
    }

    private void Init()
    {
        _currentSpeed = _startSpeed;
        _acceleration = (_endSpeed - _startSpeed) / _duration;
    }

    private void Move()
    {
        _currentSpeed += _acceleration * Time.deltaTime;
        _currentSpeed = Mathf.Min(_currentSpeed, _endSpeed);

        transform.Translate(Vector3.up * _currentSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") == false) return;

        HandleCollision(collision);
    }

    private void HandleCollision(Collider2D collision)
    {
        BodyPart bodyPart = collision.GetComponent<BodyPart>();
        if (bodyPart == null) return;
        bodyPart.Hit(Damage);

        gameObject.SetActive(false);
    }
}