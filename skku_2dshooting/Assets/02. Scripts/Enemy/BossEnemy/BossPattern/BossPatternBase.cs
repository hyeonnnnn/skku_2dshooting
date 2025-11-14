using System.Collections;

public abstract class BossPatternBase
{
    protected Boss _boss;

    protected BossPatternBase(Boss boss)
    {
        _boss = boss;
    }

    public abstract IEnumerator Execute(Boss _boss);
}
