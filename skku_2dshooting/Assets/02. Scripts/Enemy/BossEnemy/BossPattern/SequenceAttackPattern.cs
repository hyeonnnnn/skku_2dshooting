using System.Collections;
using UnityEngine;

public class SequenceAttackPattern : BossPatternBase
{
    public SequenceAttackPattern(Boss boss) : base(boss) { }

    public override IEnumerator Execute()
    {
        Debug.Log("지그재그 공격 패턴 시작");
        yield return _boss.StartCoroutine(_boss.SequenceAttack());
    }
}
