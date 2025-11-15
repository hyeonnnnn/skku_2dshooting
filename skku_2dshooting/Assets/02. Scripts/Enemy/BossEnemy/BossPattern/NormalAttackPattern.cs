using System.Collections;
using UnityEngine;

public class NormalAttackPattern : BossPatternBase
{
    public NormalAttackPattern(Boss boss) : base(boss) { }

    public override IEnumerator Execute()
    {
        Debug.Log("일반 공격 패턴 시작");
       
        //float timer = 0f;
        //float coolTime = 1.5f;
        //int attackCount = 5;

        //for (int i = 0; i < attackCount; i++)
        //{
        //    foreach (var firePosition in _firePositions)
        //    {
        //        BulletFactory.Instance.MakeBossBullet(firePosition.position);

        //    }
        //    timer = 0;
        //    while (timer < coolTime)
        //    {
        //        timer += Time.deltaTime;
        //        yield return null;
        //    }
        //}

        yield return new WaitForSeconds(_waitTime);
    }
}
