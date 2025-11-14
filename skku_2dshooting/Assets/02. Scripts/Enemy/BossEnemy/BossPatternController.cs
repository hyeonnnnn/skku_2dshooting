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

        Debug.Log("패턴 추가하기");
        _patterns.Add(new NormalAttackPattern(_boss));
        _patterns.Add(new RushAttackPattern(_boss));
    }

    public IEnumerator StartPattern()
    {
        Debug.Log("패턴 시작하기");
        while (true)
        {
            foreach (var pattern in _patterns)
            {
                Debug.Log($"{pattern}을 실행");
                yield return _boss.StartCoroutine(pattern.Execute(_boss));
            }
        }
    }
}
