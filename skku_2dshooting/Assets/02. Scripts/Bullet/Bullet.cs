using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 0.1f;

    private void Update()
    {
        transform.Translate(Vector3.up * Speed);
    }
}
