// virus�� SO������ �޾ƿͼ� �ൿ�ϱ�.
using UnityEngine;

public class VirusIdle : BaseState
{
    public VirusIdle(Virus virus) : base(virus) { }

    public override void OnStateEnter()
    {
        Debug.Log("Idle �����Դϴ�.");
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        
    }
}

public class VirusAtk : BaseState
{
    public VirusAtk(Virus virus) : base(virus) { }

    public override void OnStateEnter()
    {
        Debug.Log("ATK �����Դϴ�.");
    }

    public override void OnStateUpdate()
    {

    }

    public override void OnStateExit()
    {

    }
}

public class VirusDef : BaseState
{
    public VirusDef(Virus virus) : base(virus) { }

    public override void OnStateEnter()
    {
        Debug.Log("DEF �����Դϴ�.");
    }

    public override void OnStateUpdate()
    {

    }

    public override void OnStateExit()
    {

    }
}

public class VirusSup : BaseState
{
    public VirusSup(Virus virus) : base(virus) { }

    public override void OnStateEnter()
    {
        Debug.Log("SUP �����Դϴ�.");
    }

    public override void OnStateUpdate()
    {

    }

    public override void OnStateExit()
    {

    }
}
public class VirusDeath : BaseState
{
    public VirusDeath(Virus virus) : base(virus) { }

    public override void OnStateEnter()
    {
        Debug.Log("DEATH �����Դϴ�.");
    }

    public override void OnStateUpdate()
    {

    }

    public override void OnStateExit()
    {

    }
}