using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyBase
{
    public override void Dead()
    {
        base.Dead();
    }

    public override void move()
    {
        base.move();
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void CDCount()
    {
        base.CDCount();
    }
}
