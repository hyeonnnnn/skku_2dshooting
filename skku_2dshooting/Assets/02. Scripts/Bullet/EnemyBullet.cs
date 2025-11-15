using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("이동 속도")]
    [SerializeField] private float _startSpeed = 0.02f;
    [SerializeField] private float _endSpeed = 0.03f;
    [SerializeField] private float _duration = 0.5f;
    private float _currentSpeed;
    private float _acceleration;

    [Header("스탯")]
    [SerializeField] private float _damage;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        _currentSpeed = _startSpeed;
        _acceleration = (_endSpeed - _startSpeed) / _duration;

    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _currentSpeed += _acceleration * Time.deltaTime;
        _currentSpeed = Mathf.Min(_currentSpeed, _endSpeed);

        transform.Translate(Vector3.up * _currentSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;

        PlayerStatus player = collision.GetComponent<PlayerStatus>();
        if (player == null) return;

        player.TakeDamage(_damage);
        gameObject.SetActive(false);
    }
}
