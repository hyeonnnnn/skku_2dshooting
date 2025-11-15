using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternController
{
    private readonly Boss _boss;
    private readonly List<BossPatternBase> _patterns = new List<BossPatternBase>();
    private float _term = 2f;

    public BossPatternController(Boss boss)
    {
        _boss = boss;

        _patterns.Add(new NormalAttackPattern(_boss));
        _patterns.Add(new RushAttackPattern(_boss));
        _patterns.Add(new SequenceAttackPattern(_boss));
    }

    public IEnumerator StartPattern()
    {
        foreach (var pattern in _patterns)
        {
            yield return new WaitForSeconds(_term);
            yield return _boss.StartCoroutine(pattern.Execute());
        }

        _boss.NotifyPatternEnd();
    }
}
