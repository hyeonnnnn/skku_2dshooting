using UnityEngine;

public class Item : MonoBehaviour
{
    private float _speedValue = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            TrySpeedUp(collision);
        }
    }

    private void TrySpeedUp(Collider2D collision)
    {
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        playerMove.SpeedUp(_speedValue);
        Destroy(gameObject);
    }
}
