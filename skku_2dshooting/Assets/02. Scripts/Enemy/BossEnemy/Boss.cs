using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private BossPatternController _bossPatternController;

    [Header("총구")]
    [SerializeField] private Transform[] _firePositions;

    [Header("이펙트")]
    [SerializeField] private ParticleSystem _damageEffect;
    [SerializeField] private ParticleSystem _appearEffect;
    [SerializeField] private ParticleSystem _disappearEffect;

    private Vector3 _originPosition;
    private Vector3 _targetPosition;

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
        Instantiate(_appearEffect, transform.position, Quaternion.identity);


        StartCoroutine(_bossPatternController.StartPattern());
    }

    private void OnDisable()
    {
        Instantiate(_disappearEffect, transform.position, Quaternion.identity);
    }

    public IEnumerator NormalAttack()
    {
        float coolTime = 1.5f;
        int attackCount = 5;
        float timer = 0f;

        for (int i = 0; i < attackCount; i++)
        {
            foreach (var firePosition in _firePositions)
            {
                BulletFactory.Instance.MakeBossBullet(firePosition.position);

            }
            timer = 0;
            while (timer < coolTime)
            {
                timer += Time.deltaTime;
                yield return null;
            }
        }
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

    public IEnumerator SequenceAttack()
    {
        float duration = 0.3f;
        float term = 0.1f;
        float timer = 0f;

        while (timer < duration)
        {
            foreach (var firePosition in _firePositions)
            {
                BulletFactory.Instance.MakeBossBullet(firePosition.position);
                timer += Time.deltaTime;
                yield return new WaitForSeconds(term);
            }
            
        }
    }

}
