using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallEnemy : EnemyBase
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
        health = 50 + 10 * enemyGeneratorController.instance.level;
        attack = 5 + 2 * enemyGeneratorController.instance.level;
        cdm = 1;
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
