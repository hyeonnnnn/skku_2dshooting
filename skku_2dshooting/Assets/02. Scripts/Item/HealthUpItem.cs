using UnityEngine;

public class HealthUpItem : Item
{
    [SerializeField] private float _healthUpValue = 1f;

    protected override void OnCollect(Collider2D collision)
    {
        PlayerStatus player = collision.GetComponent<PlayerStatus>();
        player.HealthUp(_healthUpValue);
        Disappear();
    }
}
