using UnityEngine;

public class MoveState : IState
{
    private AIController _aiController;

    public MoveState(AIController aIController)
    {
        _aiController = aIController;
    }

    public void Enter()
    {
        Debug.Log("Move State에 들어옴");
    }

    public void Update()
    {
        // 타겟 감지
        Transform target = _aiController.DetectTarget();
        if (target == null)
        {
            _aiController.SwitchState(new IdleState(_aiController));
            return;
        }

        // 타겟 정면으로 이동
        _aiController.MoveTowardsTarget();

        // 위험 반경에 들어오면 EvadeState로 전환
        float _dangerZoneRadious = _aiController.GetDangerZoneRadius();
        float distance = Vector2.Distance(_aiController.transform.position, target.position);
        if(distance > _dangerZoneRadious) return;
        
        _aiController.SwitchState(new EvadeState(_aiController));
    }

    public void Exit()
    {
        Debug.Log("Move State에서 나감");
    }
}
