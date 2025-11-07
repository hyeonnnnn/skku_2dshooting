using UnityEngine;

public class IdleState : IState
{
    private AIController _aiController;

    public IdleState(AIController aIController)
    {
        _aiController = aIController;
    }

    public void Enter()
    {
        Debug.Log("Idle State에 들어옴");
    }

    public void Update()
    {
        Transform target = _aiController.DetectTarget();
        if (target != null)
        {
            _aiController.SwitchState(new MoveState(_aiController));
        }
    }

    public void Exit()
    {
        Debug.Log("Idle State에서 나감");
    }
}
