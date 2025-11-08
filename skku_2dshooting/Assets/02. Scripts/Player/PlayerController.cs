using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("컴포넌트")]
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerFire _playerFire;
    [SerializeField] private AIController _aIController;

    [Header("전투 모드")]
    [SerializeField] private bool _isAutoCombatMode = true;

    private void Update()
    {
        SwitchCombatMode();

        if(_isAutoCombatMode == true)
        {
            AutoCombatMode();
        }
        else
        {
            ManualCombatMode();
        }
    }

    private void SwitchCombatMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _isAutoCombatMode = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _isAutoCombatMode = false;
        }
    }

    private void AutoCombatMode()
    {
        _aIController.enabled = true;
        _playerMove.enabled = false;

        _aIController.UpdateAI();
        _playerFire.HandleAutolFire();
    }

    private void ManualCombatMode()
    {
        _playerMove.enabled = true;
        _aIController.enabled = false;

        _playerMove.HandleMovement();
        _playerFire.HandleManualFire();
    }
}
