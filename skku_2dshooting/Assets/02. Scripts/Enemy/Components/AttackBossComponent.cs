using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackBossComponent : MonoBehaviour
{
    private int _nextPatternIndex = 0;

    private static readonly int IDLE = 0;
    private static readonly int RUSH = 1;
    private static readonly int FIREBULLET = 2;
    private static readonly int FIRECIRCLEBULLET = 3;
    private static readonly int END = 3;

    private GameObject _player;

    [Header("공격 설정값")]
    [SerializeField] private float _damage = 2;
    [SerializeField] private Transform[] _firePositions;

    [Header("공격 이펙트")]
    [SerializeField] private ParticleSystem _damageEffect;
    [SerializeField] private ParticleSystem _appearEffect;

    private bool isPatternEnd;
    public bool IsPatternEnd => isPatternEnd;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        _nextPatternIndex = 0;
        if (_appearEffect != null)
        {
            Instantiate(_appearEffect, transform.position, Quaternion.identity);
        }
            
        NextPatternPlay();
    }

    private IEnumerator Idle()
    {
        Debug.Log("Idle 시작");
        yield return new WaitForSeconds(3f);

        NextPatternPlay();
    }


    private IEnumerator Rush()
    {
        Debug.Log("Rush 시작");
        float speed = 10f;
        float rushDuration = 0.8f;
        float returnDuration = 0.8f;

        Vector3 originPosition = transform.position;
        Vector3 targetPosition = _player.transform.position;

        // 1. rush
        float timer = 0f;
        while (timer < rushDuration)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        // 2. return
        timer = 0f;
        while (timer < returnDuration)
        {
            transform.position = Vector3.MoveTowards(transform.position, originPosition, speed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(2f);
        NextPatternPlay();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attack(collision);
    }

    private void Attack(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;

        PlayerStatus player = collision.GetComponent<PlayerStatus>();
        if (player == null) return;

        player.TakeDamage(_damage);
        Instantiate(_damageEffect, transform.position, Quaternion.identity);
    }

    private IEnumerator FireBullet()
    {
        Debug.Log("FireBullet 시작");

        float timer = 0f;
        float coolTime = 1.5f;
        int attackCount = 5;

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
        
        yield return new WaitForSeconds(2f);
        NextPatternPlay();
    }

    private void NextPatternPlay()
    {
        switch (_nextPatternIndex)
        {
            case 0:
                StartCoroutine(Idle());
                _nextPatternIndex++;
                break;
            case 1:
                StartCoroutine(Rush());
                _nextPatternIndex++;
                break;
            case 2:
                StartCoroutine(FireBullet());
                _nextPatternIndex++;
                break;
            case 3:
                isPatternEnd = true;
                break;
        }
    }
}
