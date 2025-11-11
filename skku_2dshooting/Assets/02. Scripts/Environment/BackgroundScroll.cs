using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Material _material;
    [SerializeField] private float _scrollSpeed = 1f;

    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        _material = renderer.material;
    }

    private void Update()
    {
        Vector2 direction = Vector2.up;
        _material.mainTextureOffset += direction * _scrollSpeed * Time.deltaTime;
    }
}
