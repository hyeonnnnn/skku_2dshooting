using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [Header("공격 설정")]
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attack(collision);
    }

    // 플레이어에게 공격
    private void Attack(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;

        Player player = collision.GetComponent<Player>();
        if (player == null) return;

        player.Hit(_damage);

        Destroy(this.gameObject);
    }
}
