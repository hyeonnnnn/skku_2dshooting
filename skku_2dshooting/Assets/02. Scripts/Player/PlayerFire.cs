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

    private PlayerStatus _playerStatus;
    private float _timer = 0f;

    private void Awake()
    {
        _playerStatus = GetComponent<PlayerStatus>();
    }

    public void HandleAutolFire()
    {
        _timer += Time.deltaTime;
        if (_timer < _playerStatus.CurrentFireCoolTime) return;

        _timer = 0f;
        Fire();
    }

    public void HandleManualFire()
    {
        _timer += Time.deltaTime;
        if (_timer < _playerStatus.CurrentFireCoolTime) return;

        if (Input.GetKey(KeyCode.Space))
        {
            _timer = 0f;
            Fire();
        }
    }

    private void Fire()
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
}
