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
    private float _cooltimer = 0f;
    private float _coolTime = 0.8f;
    private float _minCoolTime = 0.1f;

    [Header("자동 모드")]
    private bool _isAutoMode = true;

    private void Update()
    {
        TryFireBullet();
        ChangeAttackMode();
    }

    private void TryFireBullet()
    {
        _cooltimer += Time.deltaTime;
        if (_cooltimer < _coolTime) return;

        if (Input.GetKey(KeyCode.Space)||_isAutoMode)
        {
            _cooltimer = 0f;
            MakeBullets();
        }
    }

    private void MakeBullets()
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

    private void ChangeAttackMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) _isAutoMode = true;
        else if (Input.GetKeyDown(KeyCode.Alpha2))_isAutoMode = false;
    }

    public void AttackSpeedUp(float value)
    {
        _coolTime -= value;
        Mathf.Min(_coolTime, _minCoolTime);
    }
}
