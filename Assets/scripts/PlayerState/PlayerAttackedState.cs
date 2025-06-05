using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackedState : PlayerState
{
    public float attackedtime;
    public override void Enter()
    {
        base.Enter();
        Player.instance.AttackedAnim();
        Player.instance.attacked = true;
        attackedtime = Player.instance.attackedtime;
    }

    public override void Exit()
    {
        Player.instance.attacked = false;
        base.Exit();
    }

    public override void update()
    {   
        base.update();
        attackedtime -= Time.deltaTime;
        if (attackedtime <= 0) 
        { 
            Player.instance.ChangeState(new PlayerNormalState());
        }
    }
}
