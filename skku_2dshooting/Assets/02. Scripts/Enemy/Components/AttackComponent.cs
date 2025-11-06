using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attack(collision);
    }

    // 플레이어에게 공격
    private void Attack(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;

        GameObject playerGameObject = collision.gameObject;
        Player player = playerGameObject.GetComponent<Player>();

        player.Hit(_damage);

        Destroy(this.gameObject);
    }
}
