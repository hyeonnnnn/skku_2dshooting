using UnityEngine;

public class AttackSpeedUpItem : Item
{
    [SerializeField] private float _attackSpeedValue = 0.07f;

    protected override void OnCollect(Collider2D collision)
    {
        Debug.Log("공속 증가");
        PlayerFire player = collision.GetComponent<PlayerFire>();
        player.AttackSpeedUp(_attackSpeedValue);
        Disappear();
    }
}
