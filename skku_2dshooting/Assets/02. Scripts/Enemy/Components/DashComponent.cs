using Unity.VisualScripting;
using UnityEngine;

public class DashComponent : MonoBehaviour
{
    [Header("이동 속도")]
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _dashSpeed = 5f;

    [Header("탐지 반경")]
    [SerializeField] private float _detectionRadius = 2.5f;

    private Vector2 _direction = Vector2.down;

    private void Update()
    {
        DetectPlayer();
        Move();
    }

    private void DetectPlayer()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);
        if (hitObjects.Length == 0) return;

        foreach (Collider2D hit in hitObjects)
        {
            if (hit.gameObject.CompareTag("Player") == false) continue;
            
            Vector2 directionToPlayer = (hit.transform.position - transform.position).normalized;
            _direction = directionToPlayer;
            _speed = _dashSpeed;
            break;
        }
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
