using System.Collections;
using UnityEngine;

public class SequenceAttackPattern : BossPatternBase
{
    public SequenceAttackPattern(Boss boss) : base(boss) { }

    public override IEnumerator Execute()
    {
        yield return _boss.StartCoroutine(_boss.SequenceAttack());
    }
}
