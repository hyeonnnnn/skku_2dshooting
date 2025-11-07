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
        Debug.Log("체력 증가");
        Player player = collision.GetComponent<Player>();
        player.HealthUp(_healthUpValue);
        Disappear();
    }

    protected override void Disappear()
    {
        Destroy(gameObject);
    }
}
