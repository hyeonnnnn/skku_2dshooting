using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("스탯")]
    private float _health = 100f;
    private float _speed = 3.0f;
    private float _damage = 1f;

    private void Update()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    public void Hit(float damage)
    {
        Debug.Log($"Enemy Hit! Damage: {damage}");
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;

        GameObject playerGameObject = collision.gameObject;
        Player player = playerGameObject.GetComponent<Player>();
        
        player.Hit(_damage);

        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Debug.Log("충돌 지속");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Debug.Log("충돌 종료");
    }
}
