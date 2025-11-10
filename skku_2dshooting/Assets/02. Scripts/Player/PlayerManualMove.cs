using UnityEngine;

public class PlayerManualMove : MonoBehaviour
{
    private PlayerStatus _playerStatus;
    private Vector2 _originPosition;
    private Animator _animator;

    private void Awake()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _animator = GetComponent<Animator>();
        _originPosition = transform.position;
    }

    public void HandleMovement()
    {
        float finalSpeed = _playerStatus.BaseSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed *= _playerStatus.DashMultiplier;
        }
        if (Input.GetKey(KeyCode.R))
        {
            MoveToOrigin(finalSpeed);
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(h, v).normalized;

        _animator.SetInteger("x", direction.x > 0 ? 1 : direction.x < 0 ? -1 : 0);

        Vector2 newPosition = (Vector2)transform.position + (direction * finalSpeed) * Time.deltaTime;
        transform.position = newPosition;
    }

    private void MoveToOrigin(float speed)
    {
        Vector2 direction = (_originPosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
