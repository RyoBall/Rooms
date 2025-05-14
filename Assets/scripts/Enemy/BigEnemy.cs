using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : EnemyBase
{
    [SerializeField] GameObject bullet;
    public override void Dead()
    {
        base.Dead();
    }

    public override void move()
    {
        base.move();
    }

    public override void Start()
    {
        base.Start();
        health = 100 + 20 * enemyGeneratorController.instance.level;
        attack=  5+2* enemyGeneratorController.instance.level;
        cdm = 5;
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void CDCount()
    {
        base.CDCount();
    }
    protected void Attack() 
    {
        if (cd <= 0) 
        {
            GameObject Bul=Instantiate(bullet, transform.position, Quaternion.identity);
            Bul.GetComponent<EnemyBullet>().attack = attack;
        }
    }
}
