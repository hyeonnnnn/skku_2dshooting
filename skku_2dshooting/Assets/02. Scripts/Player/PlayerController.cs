using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("컴포넌트")]
    [SerializeField] private PlayerManualMove _playerManualMove;
    [SerializeField] private PlayerAutoMove _playerAutoMove;
    [SerializeField] private PlayerFire _playerFire;

    [Header("전투 모드")]
    [SerializeField] private bool _isAutoCombatMode = true;

    [Header("이동 제한")]
    [SerializeField] private float _padding = 0.3f;
    [SerializeField] private float _maxViewportY = 0.6f;
    private Camera _camera;

    private const KeyCode UseAutoCombatlKey = KeyCode.Alpha1;
    private const KeyCode UseManaulCombatKey = KeyCode.Alpha2;
    private const KeyCode UseSkillKey = KeyCode.Alpha3;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        SwitchCombatMode();
        TryUseSkill();

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
        if (Input.GetKeyDown(UseAutoCombatlKey))
        {
            _isAutoCombatMode = true;
        }
        else if (Input.GetKeyDown(UseManaulCombatKey))
        {
            _isAutoCombatMode = false;
        }
    }

    private void TryUseSkill()
    {
        if (Input.GetKeyDown(UseSkillKey))
        {
            _playerFire.TryUseUltimateSkill();
        }
    }

    private void AutoCombatMode()
    {
        _playerAutoMove.enabled = true;
        _playerManualMove.enabled = false;

        _playerAutoMove.UpdateAI();
        _playerFire.HandleAutolFire();
    }

    private void ManualCombatMode()
    {
        _playerManualMove.enabled = true;
        _playerAutoMove.enabled = false;

        _playerManualMove.HandleMovement();
        _playerFire.HandleManualFire();
    }

    private void ClampPositionToScreen()
    {
        if (_camera == null) return;

        float distance = transform.position.z - _camera.transform.position.z;

        Vector3 min = _camera.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 maxX = _camera.ViewportToWorldPoint(new Vector3(1f, 1f, distance));
        Vector3 maxY = _camera.ViewportToWorldPoint(new Vector3(0f, _maxViewportY, distance));

        float clampedX = Mathf.Clamp(transform.position.x, min.x + _padding, maxX.x - _padding);
        float clampedY = Mathf.Clamp(transform.position.y, min.y + _padding, maxY.y - _padding);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
