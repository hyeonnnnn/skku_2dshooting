using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeAmount = 0.2f;
    [SerializeField] private float _shakeTime = 0.4f;
    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float timer = 0;
        while (timer <= _shakeTime)
        {
            Vector2 offset = UnityEngine.Random.insideUnitCircle * _shakeAmount;

            transform.position = new Vector3(
                _initialPosition.x + offset.x,
                _initialPosition.y + offset.y,
                _initialPosition.z
            );

            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = _initialPosition;
    }

}
