using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class PlayerFire : MonoBehaviour
{
    [Header("총알 프리팹")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _subBulletPrefab;

    [Header("총구")]
    [SerializeField] private Transform _leftFirePosition;
    [SerializeField] private Transform _rightFirePosition;
    [SerializeField] private Transform _leftSubFirePosition;
    [SerializeField] private Transform _rightSubFirePosition;

    [Header("쿨타임")]
    private float _baseCoolTime = 0.8f;
    private float _minCoolTime = 0.4f;
    private float _currentCoolTime = 0f;
    private float _cooltimer = 0f;

    [Header("공격 모드")]
    private bool _isAutoMode = true;


    private void Awake()
    {
        _currentCoolTime = _baseCoolTime;
    }

    private void Update()
    {
        TryFire();
        SwitchAttackMode();
    }

    private void TryFire()
    {
        _cooltimer += Time.deltaTime;
        if (_cooltimer < _currentCoolTime) return;

        if (Input.GetKey(KeyCode.Space)||_isAutoMode)
        {
            _cooltimer = 0f;
            FireBullets();
        }
    }

    private void FireBullets()
    {
        InstantiateBullet(_bulletPrefab, _leftFirePosition);
        InstantiateBullet(_bulletPrefab, _rightFirePosition);
        InstantiateBullet(_subBulletPrefab, _leftSubFirePosition);
        InstantiateBullet(_subBulletPrefab, _rightSubFirePosition);
    }

    private void InstantiateBullet(GameObject prefab, Transform firePosition)
    {
        GameObject bullet = Instantiate(prefab, firePosition.position, Quaternion.identity);
    }

    private void SwitchAttackMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) _isAutoMode = true;
        if (Input.GetKeyDown(KeyCode.Alpha2))_isAutoMode = false;
    }

    public void AttackSpeedUp(float value)
    {
        _currentCoolTime = Mathf.Max(_currentCoolTime - value, _minCoolTime);
    }
}
