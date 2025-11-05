using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("스탯")]
    public float Health = 100f;
    private float _speed = 3.0f;

    private void Update()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;

        GameObject playerGameObject = collision.gameObject;
        PlayerStatus playerStatus = playerGameObject.GetComponent<PlayerStatus>();
        playerStatus.LifeCount -= 1;

        if (playerStatus.LifeCount <= 0)
        {
            Destroy(playerGameObject);
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("충돌 지속");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("충돌 종료");
    }
}
