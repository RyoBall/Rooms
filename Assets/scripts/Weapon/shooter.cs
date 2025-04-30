using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shooter : WeaponBase
{
    public GameObject bullet;
    public override void Attack()
    {
        base.Attack();
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        if (cd <= 0 && enemysin.Count != 0)
        {
            cd = cdm;
            DIR();
            shoot();
            if (doubleattack)
                StartCoroutine(doubleroutine());
        }
    }
    IEnumerator doubleroutine() 
    {
        yield return new WaitForSeconds(.1f);
        shoot();
    }
    void shoot() 
    {
        GameObject ins = Instantiate(bullet, transform.position, Quaternion.identity);
        ins.GetComponent<bullet>().dir = dir;
        ins.GetComponent<bullet>().attack=AttackCount();
    }
    public override void DIR()
    {
        base.DIR();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
