using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : EnemyBase
{
    public override void Dead()
    {
        base.Dead();
    }

    public override void move()
    {
        base.move();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void Start()
    {
        base.Start();
        health = 50 + 20 * enemyGeneratorController.instance.level;
        attack=  5+2* enemyGeneratorController.instance.level;
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
