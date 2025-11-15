using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bossEnemyObject;

    private int _spawnScore = 20000;
    private int _nextSpawnScore;

    private void Awake()
    {
        _nextSpawnScore = _spawnScore;
        _bossEnemyObject.SetActive(false);

    }

    private void Update()
    {
        CheckScore();
    }

    private void CheckScore()
    {
        int currentScore = ScoreManager.Instance.CurrentScore;

        if (currentScore >= _nextSpawnScore)
        {
            SpawnBossEnemy();
            _nextSpawnScore += _spawnScore;
        }
    }

    private void SpawnBossEnemy()
    {
        _bossEnemyObject.SetActive(true);
    }

    public void EndBossEnemy()
    {
        _bossEnemyObject.SetActive(false);
    }
}
