using UnityEngine;

public class AttackSpeedUpItem : Item
{
    [SerializeField] private float _attackSpeedValue = 0.07f;

    protected override void OnCollect(Collider2D collision)
    {
        PlayerFire player = collision.GetComponent<PlayerFire>();
        player.AttackSpeedUp(_attackSpeedValue);
        Disappear();
    }
}
