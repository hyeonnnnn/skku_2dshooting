using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval = 2f;

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
        GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
    }

    private void ResetSpawnInterval()
    {
        float randomNumber = UnityEngine.Random.Range(1f, 3f);
        _spawnInterval = randomNumber;
    }
}
