using UnityEngine;

public class MoveSpeedUpItem : Item
{
    private float _speedValue = 0.2f;

    protected override void OnCollect(Collider2D collision)
    {
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        playerMove.SpeedUp(_speedValue);
        Disappear();
    }
}
