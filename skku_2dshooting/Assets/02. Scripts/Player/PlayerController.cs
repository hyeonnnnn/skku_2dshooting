using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("컴포넌트")]
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerFire _playerFire;
    [SerializeField] private AIController _aIController;

    [Header("전투 모드")]
    [SerializeField] private bool _isAutoCombatMode = true;

    [Header("이동 제한")]
    [SerializeField] private float _padding = 0.3f;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

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

        ClampPositionToScreen();
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

    private void ClampPositionToScreen()
    {
        if (_camera == null) return;

        Vector3 min = _camera.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - _camera.transform.position.z));
        Vector3 max = _camera.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z - _camera.transform.position.z));

        float clampedX = Mathf.Clamp(transform.position.x, min.x + _padding, max.x - _padding);
        float clampedY = Mathf.Clamp(transform.position.y, min.y + _padding, max.y - _padding);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
