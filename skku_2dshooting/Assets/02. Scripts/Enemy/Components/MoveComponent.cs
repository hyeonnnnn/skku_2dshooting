using UnityEngine;

public abstract class MoveComponent : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 1f;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();
}
