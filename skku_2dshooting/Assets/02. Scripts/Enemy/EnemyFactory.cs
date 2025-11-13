using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private static EnemyFactory _instance;
    public static EnemyFactory Instance => _instance;

    [Header("적 테이블")]
    [SerializeField] private EnemyTable _enemyTable;

    [Header("풀링")]
    [SerializeField] private int _poolSize = 15;
    private Dictionary<string, GameObject[]> _enemyPools; 

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        InitPool();
    }

    private void InitPool()
    {
        _enemyPools = new Dictionary<string, GameObject[] >();

        foreach (var data in _enemyTable.enemys)
        {
            string key = data.EnemyName;

            // 풀 배열 만들기
            GameObject[] pool = new GameObject[_poolSize];
            _enemyPools[key] = pool;

            // 풀 채우기
            for (int i = 0; i < _poolSize; i++)
            {
                GameObject enemyObject = Instantiate(data.EnemyPrefab, transform);
                pool[i] = enemyObject;
                enemyObject.SetActive(false);
            }
        }
    }


    public GameObject MakeEnemy(string enemyName, Vector3 position)
    {
        var pool = _enemyPools[enemyName];
        foreach (var enemy in pool)
        {
            if (enemy.activeInHierarchy == false)
            {
                enemy.transform.position = position;
                enemy.SetActive(true);
                return enemy;
            }
        }
        Debug.LogError("적 개수가 부족합니다. [정희연을 찾아주세요.]");
        return null;
    }
}
