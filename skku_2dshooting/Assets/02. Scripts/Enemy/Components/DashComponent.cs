using Unity.VisualScripting;
using UnityEngine;

public class DashComponent : MonoBehaviour
{
    [Header("이동 속도")]
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _dashSpeed = 5f;

    [Header("탐지 반경")]
    [SerializeField] private float _detectionRange = 2.5f;

    private GameObject _player;
    private bool _isDashing = false;

    private Vector2 _direction = Vector2.down;
    private float _angleToPlayer;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        DetectPlayer();
        Move();
    }

    private void DetectPlayer()
    {
        if(_isDashing) return;
        if (_player == null) return;

        float distance = Vector2.Distance(transform.position, _player.transform.position);
        if(distance > _detectionRange) return;

        _isDashing = true;

        _angleToPlayer = Mathf.Atan2(
            _player.transform.position.y - transform.position.y,
            _player.transform.position.x - transform.position.x)
            * Mathf.Rad2Deg;
    }

    private void Move()
    {
        if (_player == null) return;

        if (_isDashing)
        {
            _direction = (_player.transform.position - transform.position).normalized;
            transform.Translate(_direction * _dashSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, _angleToPlayer + 90f);
        }
        else
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}
