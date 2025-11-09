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

    }

    public void Execute()
    {
        Transform target = _aiController.UpdateTarget();
        if (target != null)
        {
            _aiController.SwitchState(new MoveState(_aiController));
        }
    }

    public void Exit()
    {

    }
}
