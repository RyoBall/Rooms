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
            GameObject ins=Instantiate(bullet, transform.position, Quaternion.identity);
            ins.GetComponent<bullet>().dir = dir;
        }
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
