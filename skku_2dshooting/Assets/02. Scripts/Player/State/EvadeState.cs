using UnityEngine;

public class EvadeState : IState
{
    private AIController _aiController;

    public EvadeState(AIController aIController)
    {
        _aiController = aIController;
    }

    public void Enter()
    {

    }

    public void Execute()
    {
        // 타겟 감지
        Transform target = _aiController.UpdateTarget();
        if (target == null)
        {
            _aiController.SwitchState(new IdleState(_aiController));
            return;
        }

        // 타겟으로부터 도망
        _aiController.EvadeFromTarget();

        // 충분히 멀어졌으면 IdleState로 전환
        float _dangerZoneRadious = _aiController.GetDangerZoneRadius();
        float distance = Vector2.Distance(_aiController.transform.position, target.position);
        if (distance < _dangerZoneRadious) return;

        _aiController.SwitchState(new IdleState(_aiController));
    }

    public void Exit()
    {

    }
}
