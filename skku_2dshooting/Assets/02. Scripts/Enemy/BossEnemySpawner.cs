using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bossEnemyObject;
    private AttackBossComponent _attackBossComponent;

    private int _spawnScore = 20000;
    private int _nextSpawnScore;

    private void Awake()
    {
        _nextSpawnScore = _spawnScore;
        _bossEnemyObject.SetActive(false);
        _attackBossComponent = _bossEnemyObject.GetComponent<AttackBossComponent>();

    }

    private void Update()
    {
        CheckScore();
        CheckIsPatternEnd();
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

    private void CheckIsPatternEnd()
    {
        if (_attackBossComponent.IsPatternEnd == true)
        {
            EndBossEnemy();
        }
    }

    public void EndBossEnemy()
    {
        _bossEnemyObject.SetActive(false);
    }
}
