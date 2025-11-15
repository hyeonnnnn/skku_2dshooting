using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternController
{
    private Boss _boss;
    private List<BossPatternBase> _patterns = new List<BossPatternBase>();
    
    public BossPatternController(Boss boss)
    {
        _boss = boss;

        _patterns.Add(new NormalAttackPattern(_boss));
        _patterns.Add(new RushAttackPattern(_boss));
        _patterns.Add(new CircleAttackPattern(_boss));
    }

    public IEnumerator StartPattern()
    {
        while (true)
        {
            foreach (var pattern in _patterns)
            {
                yield return _boss.StartCoroutine(pattern.Execute());
            }
        }
    }
}
