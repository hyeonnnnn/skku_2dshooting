using UnityEngine;

[System.Serializable]
public struct EnemySpawnData
{
    public GameObject EnemyPrefab;
    public float SpawnChance;
}

public class EnemySpawner : MonoBehaviour
{
    [Header("적 스폰 데이터")]
    [SerializeField] private EnemySpawnData[] _enemySpawnTable;

    [Header("스폰 세팅")]
    private float _minSpawnInterval = 1f;
    private float _maxSpawnInterval = 3f;

    private float _spawnInterval = 2f;
    private float _timer = 0f;
    
    private void Start()
    {
        ResetSpawnInterval();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < _spawnInterval) return;

        SpawnEnemy();
        ResetSpawnInterval();
        _timer = 0f;
    }

    private void SpawnEnemy()
    {
        GameObject enemyPrefab = GetRandomEnemyPrefab();
        if (enemyPrefab == null)
        {
            Debug.LogError("스폰할 적 프리팹이 없습니다.");
        }

        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    private GameObject GetRandomEnemyPrefab()
    {
        if (_enemySpawnTable == null || _enemySpawnTable.Length == 0)
        {
            Debug.LogError("스폰 테이블이 비어있습니다.");
            return null;
        }

        float randomValue = Random.value;
        float cumulative = 0f;

        foreach (var enemy in _enemySpawnTable)
        {
            cumulative += enemy.SpawnChance;
            if (randomValue <= cumulative)
                return enemy.EnemyPrefab;
        }

        return _enemySpawnTable[_enemySpawnTable.Length - 1].EnemyPrefab;
    }

    private void ResetSpawnInterval()
    {
        _spawnInterval = UnityEngine.Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }
}
