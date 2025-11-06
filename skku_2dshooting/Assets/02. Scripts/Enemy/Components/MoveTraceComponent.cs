using UnityEngine;

public class MoveTraceComponent : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private GameObject playerObject;

    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Move();
    }

    // 플레이어를 따라 이동
    private void Move()
    {
        Vector2 playerPosition = playerObject.transform.position;
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
