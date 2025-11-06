using Unity.VisualScripting;
using UnityEngine;

public class DashComponent : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _dashSpeed = 3f;
    private float _radius = 2.5f;
    private Vector2 _direction;

    private void Start()
    {
        _direction = Vector2.down;
    }
    private void Update()
    {
        Move();

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach(Collider2D hit in hitObjects)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                _direction = (hit.transform.position - transform.position).normalized * _dashSpeed;
            }
        }
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
