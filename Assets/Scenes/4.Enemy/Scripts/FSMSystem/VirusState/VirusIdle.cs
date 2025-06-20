// virus�� SO������ �޾ƿͼ� �ൿ�ϱ�.
using UnityEngine;

public class VirusIdle : BaseState
{
    public VirusIdle(Virus virus) : base(virus) { }

    public override void OnStateEnter()
    {
        Debug.Log("Idle �����Դϴ�.");
        Debug.Log(_virus.virusObjectSO.name);
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
    bool inFunc = false;
    Vector2 oriPos;
    float rimitTime = 0.3f;
    float checkTime = 0f;
    float speed = 100f;
    public override void OnStateEnter()
    {
        Debug.Log("ATK �����Դϴ�.");
    }

    public override void OnStateUpdate()
    {
        Debug.Log("ATK update �����Դϴ�.");
        Vector2 enemyPos = new Vector3(-12, 0);

        if (!inFunc)
        {
            oriPos = _virus.transform.position;
            inFunc = true;
        }
        
        
        if(checkTime <= rimitTime)
        {
            checkTime = checkTime + Time.deltaTime;
            //Debug.Log(checkTime);
            _virus.transform.position = Vector2.MoveTowards(_virus.transform.position, enemyPos, speed * Time.deltaTime);
        }
        else
        {
            _virus.transform.position = Vector2.MoveTowards(_virus.transform.position, oriPos, speed * Time.deltaTime);
        }
        
        GameManager.PlayerTurn = false;
    }

    public override void OnStateExit()
    {
        Debug.Log("ATK exit �����Դϴ�.");
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