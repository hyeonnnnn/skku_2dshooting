using UnityEngine;

public abstract class MoveComponent : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();
}
