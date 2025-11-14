using System.Collections;
using UnityEngine;

public class RushAttackPattern : BossPatternBase
{
    public RushAttackPattern(Boss boss) : base(boss) { }

    public override IEnumerator Execute(Boss _boss)
    {
        Debug.Log("러쉬 공격 패턴 시작");
        //float speed = 10f;
        //float rushDuration = 0.8f;
        //float returnDuration = 0.8f;

        //Vector3 originPosition = transform.position;
        //Vector3 targetPosition = _player.transform.position;

        //// 1. 갔다가
        //float timer = 0f;
        //while (timer < rushDuration)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        //    timer += Time.deltaTime;
        //    yield return null;
        //}

        //// 2. 돌아오기
        //timer = 0f;
        //while (timer < returnDuration)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, originPosition, speed * Time.deltaTime);
        //    timer += Time.deltaTime;
        //    yield return null;
        //}
        yield return new WaitForSeconds(1f);
    }
}
