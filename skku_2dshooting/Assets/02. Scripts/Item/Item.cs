using UnityEngine;
using UnityEngine.UIElements;

public abstract class Item : MonoBehaviour
{
    [Header("아이템 이동 설정")]
    [SerializeField] private float _flySpeed = 7f;
    [SerializeField] private float _coolTime = 2f;

    [Header("베지어곡선 설정값")]
    private Transform _playerTransform;
    private Vector2 _startPoint;
    private Vector2 _controlPoint;
    private Vector2 _endPoint;
    private float _curveProgression = 0f;
    private float _controlPointHeightMin = 2f;
    private float _controlPointHeightValue = 4f;
    private float _controlPointWidthMin = -2f;
    private float _controlPointWidthMax = 2f;
    private float _curveSpeedFactor = 10f;

    private float _timer = 0f;
    private bool _isFlying = false;


    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if(player != null)
        {
            _playerTransform = player.transform;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_isFlying == false && _timer >= _coolTime)
        {
            StartBezierFly();
        }
        else if (_isFlying == true)
        {
            MoveAlongBezier();
        }
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
    protected abstract void Disappear();
    protected void StartBezierFly()
    {
        if (_playerTransform == null) return;

        _isFlying = true;
        _startPoint = transform.position;
        _endPoint = _playerTransform.position;

        Vector2 midPoint = (_startPoint + _endPoint) / 2;
        float heightOffset = Random.Range(_controlPointHeightMin, _controlPointHeightValue);

        // 아치형 곡선 만들기
        float widthOffset = Random.Range(_controlPointWidthMin, _controlPointWidthMax);
        _controlPoint = new Vector2(midPoint.x + widthOffset, midPoint.y + heightOffset); 

        _curveProgression = 0f;
    }

    protected void MoveAlongBezier()
    {
        if (_playerTransform == null) return;

        _endPoint = _playerTransform.position;

        _curveProgression += Time.deltaTime * (_flySpeed / _curveSpeedFactor);
        _curveProgression = Mathf.Min(_curveProgression, 1f);

        Vector2 bezierPosition = Mathf.Pow(1 - _curveProgression, 2) * _startPoint +
                                  2 * (1 - _curveProgression) * _curveProgression * _controlPoint +
                                  Mathf.Pow(_curveProgression, 2) * _endPoint;

        transform.position = bezierPosition;

        if (_curveProgression >= 1f)
        {
            _isFlying = false;
            Disappear();
        }
    }
}
