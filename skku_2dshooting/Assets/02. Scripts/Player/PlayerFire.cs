using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("총구")]
    [SerializeField] private Transform _leftFirePosition;
    [SerializeField] private Transform _rightFirePosition;
    [SerializeField] private Transform _leftSubFirePosition;
    [SerializeField] private Transform _rightSubFirePosition;

    private UltimateSkill _ultimateSkill;
    private PlayerStatus _playerStatus;
    private float _timer = 0f;

    private void Awake()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _ultimateSkill = GetComponent<UltimateSkill>();
    }

    public void HandleAutolFire()
    {
        _timer += Time.deltaTime;
        if (_timer < _playerStatus.CurrentFireCoolTime) return;

        _timer = 0f;
        Fire();
    }

    public void HandleManualFire()
    {
        _timer += Time.deltaTime;
        if (_timer < _playerStatus.CurrentFireCoolTime) return;

        if (Input.GetKey(KeyCode.Space))
        {
            _timer = 0f;
            Fire();
        }
    }

    public void TryUseUltimateSkill()
    {
        _ultimateSkill.UseUltimateSkill();
    }

    private void Fire()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sfx.BULLET);

        BulletFactory.Instance.MakeBullet(_leftFirePosition.position);
        BulletFactory.Instance.MakeBullet(_rightFirePosition.position);
        BulletFactory.Instance.MakeSubBullet(_leftSubFirePosition.position);
        BulletFactory.Instance.MakeSubBullet(_rightSubFirePosition.position);
    }
}
