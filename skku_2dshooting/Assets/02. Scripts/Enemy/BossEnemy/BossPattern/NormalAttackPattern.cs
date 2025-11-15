using System.Collections;
using UnityEngine;

public class NormalAttackPattern : BossPatternBase
{
    public NormalAttackPattern(Boss boss) : base(boss) { }

    public override IEnumerator Execute()
    {
        yield return _boss.StartCoroutine(_boss.NormalAttack());
    }
}
