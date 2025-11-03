using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 목표
    // 키보드를 입력할 때 입력에 따라 방향을 구하고 그 방향으로 이동시키고 싶다.

    [Header("능력치")]
    public float CurrentSpeed = 2f;
    public float MaxSpeed = 10f;
    public float MinSpeed = 0.1f;
    public float SpeedIncrement = 0.05f;

    [Header("이동범위")]
    public float MaxX = 2;
    public float MinX = -2;
    public float MaxY = 5;
    public float MinY = -5;


    // 게임 오브젝트가 게임을 시작할 때 한번만
    void Start()
    {

    }

    // 게임 오브젝트가 게임을 시작한 후에 최대한 많이
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (CurrentSpeed < MaxSpeed)
            {
                CurrentSpeed += SpeedIncrement;
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (CurrentSpeed > MinSpeed)
            {
                CurrentSpeed -= SpeedIncrement;
            }
        }

        // 1. 키보드 입력을 감지한다.
        // 유니티에는 Input 모듈이 입력에 관한 모든 것을 담당한다.
        float h = Input.GetAxis("Horizontal");  // 수평 입력에 대한 값을 -1, 0, 1로 가져온다.
        float v = Input.GetAxis("Vertical");    // 수직 입력에 대한 값을 -1, 0, 1로 가져온다.
        // GetAxis vs GetAxisRaw

        // WASD, 상하좌우 화살표로 확인할 수 있다. (디폴트)
        // Edit 설정에서 다른 키로 바인딩할 수 있다.
        // Debug.Log($"h: {h}, v: {v}");


        // 2. 입력으로부터 방향을 구한다.
        // 벡터: 크기와 방향을 표현하는 물리 개념
        Vector2 direction = new Vector2(h, v);

        // 3. 그 방향으로 이동을 한다.
        Vector2 position = transform.position; // 현재 위치
        // 새로운 위치 = 현재 위치 + (방향 * 속력) * 시간
        // 새로운 위치 = 현재 위치 + 속도 * 시간
        Vector2 newPosition = position + (direction * CurrentSpeed) * Time.deltaTime; // 새로운 위치
        // Time.deltaTime: 이전 프레임으로부터 현재 프레임까지 시간이 얼마나 흘렀는지 나타내는 값 -> 1초 / fps
        // 속도: 10
        // 컴퓨터1: 50fps -> 초당 50번 update -> 10 * 50 = 500, 500 * Time.deltaTime
        // 컴퓨터2: 100fps -> 초당 100번 update -> 10 * 100 = 1000, 1000 * Time.deltaTime
        // -> 두 컴퓨터의 값이 같아진다.
        // 이동, 회전, 확대축소에도 적용해야 한다.


        // 포지션 값에 제한을 둔다.
        // -1, 0, 1, 0.0000001 제외하고는 모두 매직넘버다.
        if (newPosition.x > MaxX)
        {
            newPosition.x = MinX;
        }
        else if (newPosition.x < MinX)
        {
            newPosition.x = MaxX;
        }
        if (newPosition.y > MaxY)
        {
            newPosition.y = MinY;
        }
        else if (newPosition.y < MinY)
        {
            newPosition.y = MaxY;
        }

        transform.position = newPosition; // 새로운 위치로 갱신

    }
}
