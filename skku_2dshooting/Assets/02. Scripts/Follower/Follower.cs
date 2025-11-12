using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _firePosition;
    [SerializeField] private float _fireCoolTime = 4f;
    private float _timer = 0;

    private void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {

    }

    private void Fire()
    {
        _timer += Time.deltaTime;

        if (_timer >= _fireCoolTime)
        {
            GameObject bullet = Instantiate(_bullet, _firePosition.transform.position, Quaternion.identity);

            _timer = 0;
        }
    }
}
