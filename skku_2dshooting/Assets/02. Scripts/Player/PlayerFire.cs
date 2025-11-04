using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class PlayerFire : MonoBehaviour
{
    [Header("총알 프리팹")]
    public GameObject BulletPrefab;
    public GameObject SubBulletPrefab;

    [Header("총구")]
    public Transform LeftFirePosition;
    public Transform RightFirePosition;
    public Transform LeftSubFirePosition;
    public Transform RightSubFirePosition;

    [Header("쿨타임")]
    private float _cooltimer = 0f;
    private float _coolTime = 0.2f;
    
    private bool _isAutoAttackMode = true;

    private void Update()
    {
        TryFireBullet();
        ChangeAttackMode();
    }

    private void TryFireBullet()
    {
        _cooltimer += Time.deltaTime;
        if (_coolTime < 0) return; // 조기 리턴

        if (_cooltimer > _coolTime)
        {
            if (_isAutoAttackMode == true)
            {
                FireBullet();
                _cooltimer = 0f;
            }
            else if (_isAutoAttackMode == false)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    FireBullet();
                    _cooltimer = 0f;
                }
            }
        }
    }

    private void FireBullet()
    {
        InstantiateBullet(BulletPrefab, LeftFirePosition);
        InstantiateBullet(BulletPrefab, RightFirePosition);
        InstantiateBullet(SubBulletPrefab, LeftSubFirePosition);
        InstantiateBullet(SubBulletPrefab, RightSubFirePosition);
    }

    private void InstantiateBullet(GameObject prefab, Transform firePosition)
    {
        GameObject bullet = Instantiate(prefab, firePosition.position, Quaternion.identity);
    }

    private void ChangeAttackMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _isAutoAttackMode = true;
            Debug.Log("자동 공격 모드");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _isAutoAttackMode = false;
            Debug.Log("수동 공격 모드");
        }
    }
}
