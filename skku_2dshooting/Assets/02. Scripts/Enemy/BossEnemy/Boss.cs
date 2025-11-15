using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Boss : MonoBehaviour
{
    private BossPatternController _bossPatternController;

    [Header("공격 설정값")]
    [SerializeField] private float _damage = 2f;
    [SerializeField] private Transform[] _firePositions;

    [Header("공격 이펙트")]
    [SerializeField] private ParticleSystem _damageEffect;
    [SerializeField] private ParticleSystem _appearEffect;

    Vector3 _originPosition;
    Vector3 _targetPosition;

    private void Awake()
    {
        // 넌 날 모르니깐 나를 알려줄게
        _bossPatternController = new BossPatternController(this);

        _originPosition = transform.position;
        
    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        transform.position = _originPosition;
        StartCoroutine(_bossPatternController.StartPattern());
    }

    public IEnumerator RushAttack()
    {
        float speed = 5f;
        float duration = 1.5f;
        float timer = 0f;

        _targetPosition = GameObject.FindWithTag("Player").transform.position;

        while (timer < duration)
        {
            transform.position = Vector3.MoveTowards( transform.position, _targetPosition, speed * Time.deltaTime );
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;
        while (timer < duration)
        {
            transform.position = Vector3.MoveTowards( transform.position, _originPosition, speed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }

}
