using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bossEnemyObject;
    private BossPatternController _attackBossComponent;

    private int _spawnScore = 20000;
    private int _nextSpawnScore;

    private void Awake()
    {
        _nextSpawnScore = _spawnScore;
        _bossEnemyObject.SetActive(false);
        _attackBossComponent = _bossEnemyObject.GetComponent<BossPatternController>();

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
            Debug.Log("보스 소환");
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
