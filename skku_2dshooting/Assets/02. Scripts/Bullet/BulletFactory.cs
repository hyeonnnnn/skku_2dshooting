using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletFactory : MonoBehaviour
{
    private static BulletFactory _instance;
    public static BulletFactory Instance => _instance;

    [Header("총알 프리팹")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _subBulletPrefab;
    [SerializeField] private GameObject _followerBulletPrefab;
    [SerializeField] private GameObject _bossBulletPrefab;

    [Header("풀링")]
    [SerializeField] private int _poolSize = 30;
    private GameObject[] _bulletObjectPool;
    private GameObject[] _subBulletObjectPool;
    private GameObject[] _followerBulletObjectPool;

    [SerializeField] private int _bossPoolSize = 100;
    private GameObject[] _bossBulletObjectPool;

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
        _bossBulletObjectPool = new GameObject[_bossPoolSize];

        for (int i = 0; i < _poolSize; i++)
        {
            _bulletObjectPool[i] = CreateInactiveInstance(_bulletPrefab);
        }
        for (int i = 0; i < _poolSize; i++)
        {
            _subBulletObjectPool[i] = CreateInactiveInstance(_subBulletPrefab);
        }
        for (int i = 0; i < _poolSize; i++)
        {
            _followerBulletObjectPool[i] = CreateInactiveInstance(_followerBulletPrefab);
        }
        for (int i = 0; i < _bossPoolSize; i++)
        {
            _bossBulletObjectPool[i] = CreateInactiveInstance(_bossBulletPrefab);
        }
    }

    public void MakeBullet(Vector3 position)
    {
        GetBulletFromPool(_bulletObjectPool, position);
    }

    public void MakeSubBullet(Vector3 position)
    {
        GetBulletFromPool(_subBulletObjectPool, position);
    }

    public void MakeFollowerBullet(Vector3 position)
    {
        GetBulletFromPool(_followerBulletObjectPool, position);
    }

    public void MakeBossBullet(Vector3 position)
    {
        GetBulletFromPool(_bossBulletObjectPool, position);
    }

    private GameObject GetBulletFromPool(GameObject[] objectPool, Vector3 position)
    {
        foreach (var bullet in objectPool)
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

    private GameObject CreateInactiveInstance(GameObject prefab)
    {
        GameObject bulletObject = Instantiate(prefab, transform);
        bulletObject.SetActive(false);
        return bulletObject;
    }
}
