using UnityEngine;

public class FireCoolTimeDownItem : Item
{
    [SerializeField] private float _fireCoolTimeDownValue = 0.07f;

    protected override void OnCollect(Collider2D collision)
    {
        PlayerStatus playerStatus = collision.GetComponent<PlayerStatus>();
        playerStatus.FireCoolTimeDown(_fireCoolTimeDownValue);
        Disappear();
    }
}
