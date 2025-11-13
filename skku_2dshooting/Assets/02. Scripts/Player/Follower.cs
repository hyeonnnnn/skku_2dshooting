using UnityEngine;
using System.Collections.Generic;

public class Follower : MonoBehaviour
{
    [Header("팔로워들")]
    [SerializeField] private GameObject[] followers;

    [Header("공격")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireCoolTime = 4f;

    [Header("따라가기")]
    private float _followSmoothness = 5f;
    private GameObject _parent;

    private List<GameObject> _spawnedFollowers = new List<GameObject>();

    private float _timer = 0f;

    private void Awake()
    {
        _parent = GameObject.FindWithTag("Player");

        float offsetY = 0.5f;
        foreach (var prefab in followers)
        {
            GameObject follower = Instantiate(prefab, _parent.transform.position + Vector3.down * offsetY, Quaternion.identity);
            _spawnedFollowers.Add(follower);
        }
    }

    private void Update()
    {
        MoveFollowers();
        Fire();
    }

    private void MoveFollowers()
    {
        Transform target = _parent.transform;
        float distance = 0.6f;

        foreach (var follower in _spawnedFollowers)
        {
            if (follower == null) continue;

            Vector3 targetPosition = target.position - Vector3.up * distance;

            follower.transform.position = Vector3.Lerp(
                follower.transform.position,
                targetPosition,
                Time.deltaTime * _followSmoothness
            );

            target = follower.transform;
        }
    }


    private void Fire()
    {
        _timer += Time.deltaTime;
        if (_timer < _fireCoolTime) return;

        float offsetY = 0.5f;
        foreach (var follower in _spawnedFollowers)
        {
            if (follower == null) continue;
            BulletFactory.Instance.MakeFollowerBullet(follower.transform.position + Vector3.up * offsetY);
        }

        _timer = 0;
    }
}