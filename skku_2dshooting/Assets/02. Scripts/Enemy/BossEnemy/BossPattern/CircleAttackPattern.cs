using System.Collections;
using UnityEngine;

public class CircleAttackPattern : BossPatternBase
{
    public CircleAttackPattern(Boss boss) : base(boss) { }

    public override IEnumerator Execute()
    {
        Debug.Log("원 공격 패턴 시작");
        
        yield return new WaitForSeconds(_waitTime);
    }
}
