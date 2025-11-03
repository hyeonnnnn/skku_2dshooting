using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 목표
    // 키보드를 입력할 때 입력에 따라 방향을 구하고 그 방향으로 이동시키고 싶다.

    public float Speed = 3f;


    // 게임 오브젝트가 게임을 시작할 때 한번만
    void Start()
    {
        
    }

    // 게임 오브젝트가 게임을 시작한 후에 최대한 많이
    void Update()
    {
        // 1. 키보드 입력을 감지한다.
        // 유니티에는 Input 모듈이 입력에 관한 모든 것을 담당한다.
        float h = Input.GetAxis("Horizontal");  // 수평 입력에 대한 값을 -1, 0, 1로 가져온다.
        float v = Input.GetAxis("Vertical");    // 수직 입력에 대한 값을 -1, 0, 1로 가져온다.

        // WASD, 상하좌우 화살표로 확인할 수 있다. (디폴트)
        // Edit 설정에서 다른 키로 바인딩할 수 있다.
        Debug.Log($"h: {h}, v: {v}");


        // 2. 입력으로부터 방향을 구한다.
        // 벡터: 크기와 방향을 표현하는 물리 개념
        Vector2 direction = new Vector2(h, v);
        Debug.Log($"direction: {direction.x}, {direction.y}");

        // 3. 그 방향으로 이동을 한다.
        Vector2 position = transform.position;                                  // 현재 위치
        // 새로운 위치 = 현재 위치 + (방향 * 속력) * 시간
        // 새로운 위치 = 현재 위치 + 속도 * 시간
        Vector2 newPosition = position + (direction * Speed) * Time.deltaTime;  // 새로운 위치
        // Time.deltaTime: 이전 프레임으로부터 현재 프레임까지 시간이 얼마나 흘렀는지 나타내는 값 -> 1초 / fps
        // 속도: 10
        // 컴퓨터1: 50fps -> 초당 50번 update -> 10 * 50 = 500, 500 * Time.deltaTime
        // 컴퓨터2: 100fps -> 초당 100번 update -> 10 * 100 = 1000, 1000 * Time.deltaTime
        // -> 두 컴퓨터의 값이 같아진다.
        // 이동, 회전, 확대축소에도 적용해야 한다.
        transform.position = newPosition;                                       // 새로운 위치로 갱신
    }
}
