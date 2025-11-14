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
            _bulletObjectPool[i] = CreateInactiveInstance(_bulletPrefab);
            _subBulletObjectPool[i] = CreateInactiveInstance(_subBulletPrefab);
            _followerBulletObjectPool[i] = CreateInactiveInstance(_followerBulletPrefab);
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
        Debug.LogError("탄창에 팔로워 총알 개수가 부족합니다. [정희연을 찾아주세요.]");
        return null;
    }

    private GameObject CreateInactiveInstance(GameObject prefab)
    {
        GameObject bulletObject = Instantiate(prefab, transform);
        bulletObject.SetActive(false);
        return bulletObject;
    }
}
