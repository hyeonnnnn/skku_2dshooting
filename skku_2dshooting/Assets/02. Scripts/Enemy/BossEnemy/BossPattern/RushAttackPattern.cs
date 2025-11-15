using System.Collections;
using UnityEngine;

public class RushAttackPattern : BossPatternBase
{
    public RushAttackPattern(Boss boss) : base(boss) { }

    public override IEnumerator Execute()
    {
        Debug.Log("러쉬 공격 패턴 시작");
        yield return _boss.StartCoroutine(_boss.RushAttack());
    }
}
