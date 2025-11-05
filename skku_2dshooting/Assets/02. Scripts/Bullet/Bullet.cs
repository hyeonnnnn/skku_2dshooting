using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("이동 속도")]
    private float _currentSpeed;
    private float _startSpeed = 0.02f;
    private float _endSpeed = 0.03f;
    private float _duration = 0.3f;
    private float _accelation;

    [Header("스탯")]
    public float Damage;

    private void Start()
    {
        _currentSpeed = _startSpeed;
        _accelation = (_endSpeed - _startSpeed) / _duration;
    }

    private void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        _currentSpeed += _accelation * Time.deltaTime;
        _currentSpeed = Mathf.Min(_currentSpeed, _endSpeed);
        transform.Translate(Vector3.up * _currentSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") == false) return;

        // GetComponent는 게임 오브젝트에 붙어 있는 컴포넌트를 가져올 수 있다.
        GameObject enemyGameObject = collision.gameObject;
        Enemy enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.Hit(Damage);
        
        Destroy(this.gameObject);
    }

}