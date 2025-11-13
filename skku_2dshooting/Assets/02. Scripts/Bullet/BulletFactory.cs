using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private static BulletFactory instance;
    public static BulletFactory Instance => instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    [Header("총알 프리팹")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _subBulletPrefab;
    [SerializeField] private GameObject _followerBulletPrefab;

    public GameObject MakeBullet(Vector3 position)
    {
        return Instantiate(_bulletPrefab, position, Quaternion.identity, transform);
    }

    public GameObject MakeSubBullet(Vector3 position)
    {
        return Instantiate(_subBulletPrefab, position, Quaternion.identity, transform);
    }

    public GameObject MakeFollowerBullet(Vector3 position)
    {
        return Instantiate(_followerBulletPrefab, position, Quaternion.identity, transform);
    }
}
