using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [Header("공격 설정")]
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _damageEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attack(collision);
    }

    // 플레이어에게 공격
    private void Attack(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;

        PlayerStatus player = collision.GetComponent<PlayerStatus>();
        if (player == null) return;

        player.TakeDamage(_damage);
        Instantiate(_damageEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
