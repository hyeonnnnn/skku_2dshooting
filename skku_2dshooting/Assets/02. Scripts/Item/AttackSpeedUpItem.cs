using UnityEngine;

public class AttackSpeedUpItem : Item
{
    private float _attackSpeedValue = 0.07f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AttackSpeedUp(collision);
        }
    }
    private void AttackSpeedUp(Collider2D collision)
    {
        Debug.Log("공속 증가");
        PlayerFire player = collision.GetComponent<PlayerFire>();
        player.AttackSpeedUp(_attackSpeedValue);
        Disappear();
    }

    protected override void Disappear()
    {
        Destroy(gameObject);
    }
}
