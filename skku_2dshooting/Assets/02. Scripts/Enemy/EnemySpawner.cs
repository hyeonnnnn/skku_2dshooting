using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _cooltime = 2f;
    private float _timer = 0f;
    
    private void Start()
    {
        float randomNumber = UnityEngine.Random.Range(1f, 2f);
        _cooltime = randomNumber;
    }

    private void Update()
    {
        HandleSpawnTimer();
    }

    private void HandleSpawnTimer()
    {
        _timer += Time.deltaTime;
        if(_timer < _cooltime) return;

        SpawnEnemy();
        _timer = 0f;
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
    }
}
