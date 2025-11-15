using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    [Header("보스")]
    [SerializeField] private GameObject _bossEnemyObject;

    [Header("이펙트")]
    [SerializeField] private ParticleSystem _appearEffect;
    [SerializeField] private ParticleSystem _disappearEffect;

    private int _spawnScore = 20000;
    private int _nextSpawnScore;

    private Boss boss;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        boss = _bossEnemyObject.GetComponent<Boss>();
        _nextSpawnScore = _spawnScore;
        _bossEnemyObject.SetActive(false);
    }

    private void Start()
    {
        ScoreManager.Instance.OnScoreReached += CheckScore;
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
        Instantiate(_appearEffect, transform.position, Quaternion.identity);

        boss.OnPatternEnd += DespawnBossEnemy;
    }

    public void DespawnBossEnemy()
    {
        _bossEnemyObject.SetActive(false);
        Instantiate(_disappearEffect, transform.position, Quaternion.identity);

        boss.OnPatternEnd -= DespawnBossEnemy;
    }
}
