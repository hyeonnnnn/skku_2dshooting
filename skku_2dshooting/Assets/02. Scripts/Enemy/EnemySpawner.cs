using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("적 테이블")]
    [SerializeField] private EnemyTable _enemyTable;

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
        if (_enemyTable == null) return null;
        if (_enemyTable.enemys.Length == 0) return null;

        float randomValue = Random.value;
        float cumulative = 0f;

        foreach (var enemy in _enemyTable.enemys)
        {
            cumulative += enemy.SpawnChance;
            if (randomValue <= cumulative)
                return enemy.EnemyPrefab;
        }

        return _enemyTable.enemys[^1].EnemyPrefab;
    }

    private void ResetSpawnInterval()
    {
        _spawnInterval = UnityEngine.Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }
}
