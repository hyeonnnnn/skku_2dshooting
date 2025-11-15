using System.Collections;

public abstract class BossPatternBase
{
    protected Boss _boss;

    protected float _waitTime = 2f;

    protected BossPatternBase(Boss boss)
    {
        _boss = boss;
    }

    public abstract IEnumerator Execute();
}
