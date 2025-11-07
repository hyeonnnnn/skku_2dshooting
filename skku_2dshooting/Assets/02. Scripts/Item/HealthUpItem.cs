using UnityEngine;

public class HealthUpItem : Item
{
    [SerializeField] private float _healthUpValue = 1f;

    protected override void OnCollect(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        player.HealthUp(_healthUpValue);
        Disappear();
    }
}
