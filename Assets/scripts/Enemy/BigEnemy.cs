using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : EnemyBase
{
    private float shootcd;
    private float shootcdm;
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
        health = 100 + 20 * enemyGeneratorController.instance.level;
        attack = 5 + 2 * enemyGeneratorController.instance.level;
        speed = 1.5f;
        costs = 10;
        cdm = 1;
        shootcdm = 5;
        base.Start();
    }
    public override void Update()
    {
        base.Update();
        Attack();
    }
    protected override void CDCount()
    {
        base.CDCount();
    }
    protected void Attack()
    {
        if (shootcd > 0)
        {
            shootcd -= Time.deltaTime;
        }
        if (shootcd <= 0 && icytime <= 0)
        {
            shootcd = shootcdm;
            GameObject Bul = Instantiate(bullet, transform.position, Quaternion.identity);
            Bul.GetComponent<EnemyBullet>().attack = attack;
            Bul.GetComponent<EnemyBullet>().Redir();
        }
    }
    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}
