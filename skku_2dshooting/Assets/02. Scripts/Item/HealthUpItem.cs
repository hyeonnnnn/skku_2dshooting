using UnityEngine;

public class HealthUpItem : Item
{
    private float _healthUpValue = 1f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthUp(collision);
        }
    }

    private void HealthUp(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        player.HealthUp(_healthUpValue);
        Dissapear();
    }

    protected override void Dissapear()
    {
        Destroy(gameObject);
    }
}
