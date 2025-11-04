using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float StartSpeed = 1.0f;
    public float EndSpeed = 7.0f;
    public float TimeTaken = 1.2f;
    private float _speed;
    private float _accelation;

    private void Start()
    {
        _speed = StartSpeed;
        _accelation = (EndSpeed - StartSpeed) / TimeTaken;
    }

    private void Update()
    {
        _speed += _accelation * Time.deltaTime;
        _speed = Mathf.Min(_speed, EndSpeed);
        transform.Translate(Vector3.up * _speed);
    }
}
