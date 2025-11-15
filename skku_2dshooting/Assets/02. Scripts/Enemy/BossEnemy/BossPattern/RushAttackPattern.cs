using System.Collections;
using UnityEngine;

public class RushAttackPattern : BossPatternBase
{
    public RushAttackPattern(Boss boss) : base(boss) { }

    public override IEnumerator Execute()
    {
        yield return _boss.StartCoroutine(_boss.RushAttack());
    }
}
