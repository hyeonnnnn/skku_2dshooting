using UnityEngine;

public class Boss : MonoBehaviour
{
    private BossPatternController _bossPatternController;

    [Header("공격 설정값")]
    [SerializeField] private float _damage = 2;
    [SerializeField] private Transform[] _firePositions;

    [Header("공격 이펙트")]
    [SerializeField] private ParticleSystem _damageEffect;
    [SerializeField] private ParticleSystem _appearEffect;
    
    private void Awake()
    {
        // 나를 알려줄게 넌 날 모르니깐
        _bossPatternController = new BossPatternController(this);
    }

    private void Start()
    {
        Debug.Log("boss start");
        StartCoroutine(_bossPatternController.StartPattern());
    }
}
