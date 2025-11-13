using JetBrains.Annotations;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private static BulletFactory _instance;
    public static BulletFactory Instance => _instance;

    [Header("총알 프리팹")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _subBulletPrefab;
    [SerializeField] private GameObject _followerBulletPrefab;

    [Header("풀링")]
    [SerializeField] private int _poolSize = 30;
    private GameObject[] _bulletObjectPool;
    private GameObject[] _subBulletObjectPool;
    private GameObject[] _followerBulletObjectPool;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        PoolInit();
    }

    private void PoolInit()
    {
        _bulletObjectPool = new GameObject[_poolSize];
        _subBulletObjectPool = new GameObject[_poolSize];
        _followerBulletObjectPool = new GameObject[_poolSize];

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bulletObject = Instantiate(_bulletPrefab, transform);
            _bulletObjectPool[i] = bulletObject;
            bulletObject.SetActive(false);

            GameObject subBulletObject = Instantiate(_subBulletPrefab, transform);
            _subBulletObjectPool[i] = subBulletObject;
            subBulletObject.SetActive(false);

            GameObject followerBulletObject = Instantiate(_followerBulletPrefab, transform);
            _followerBulletObjectPool[i] = followerBulletObject;
            followerBulletObject.SetActive(false);
        }
    }

    public GameObject MakeBullet(Vector3 position)
    {
        foreach(var bullet in _bulletObjectPool)
        {
            if (bullet.activeInHierarchy == false)
            {
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }
        Debug.LogError("탄창에 총알 개수가 부족합니다. [정희연을 찾아주세요.]");
        return null;
    }

    public GameObject MakeSubBullet(Vector3 position)
    {
        foreach (var bullet in _subBulletObjectPool)
        {
            if (bullet.activeInHierarchy == false)
            {
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }
        Debug.LogError("탄창에 서브 총알 개수가 부족합니다. [정희연을 찾아주세요.]");
        return null;
    }

    public GameObject MakeFollowerBullet(Vector3 position)
    {
        foreach (var bullet in _followerBulletObjectPool)
        {
            if (bullet.activeInHierarchy == false)
            {
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }
        Debug.LogError("탄창에 팔로워 총알 개수가 부족합니다. [정희연을 찾아주세요.]");
        return null;
    }
}
