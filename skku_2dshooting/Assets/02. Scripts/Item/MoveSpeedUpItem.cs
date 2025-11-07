using UnityEngine;

public class MoveSpeedUpItem : Item
{
    private float _speedValue = 0.2f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoveSpeedUp(collision);
        }
    }

    private void MoveSpeedUp(Collider2D collision)
    {
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        playerMove.SpeedUp(_speedValue);
        Disappear();
    }

    protected override void Disappear()
    {
        Destroy(gameObject);
    }
}
