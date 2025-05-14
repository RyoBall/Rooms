using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shooter : WeaponBase
{
    public GameObject bullet;
    public int doubleattackpoint;
    public float speedfactor;
    public override void Attack()
    {
        base.Attack();
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        if (cd <= 0 && enemysin.Count != 0)
        {
            if (heavyattacklevel > 0)
                cd = cdm * (1.4f + heavyattacklevel * .2f);
            else
                cd = cdm;
            DIR();
            shoot();
            doubleattackpoint = doubleattacklevel;
            StartCoroutine(doubleroutine());
        }
    }
    IEnumerator doubleroutine() 
    {
        yield return new WaitForSeconds(.1f);
        if (doubleattackpoint > 0) 
        {
            doubleattackpoint--;
            shoot();    
            StartCoroutine(doubleroutine());
        }
    }
    void shoot() 
    {
        GameObject ins = Instantiate(bullet, transform.position, Quaternion.identity);
        ins.GetComponent<bullet>().dir = dir;
        ins.GetComponent<bullet>().attack=AttackCount();
        ins.GetComponent<bullet>().dad=this;
        ins.GetComponent<bullet>().speedfactor=speedfactor;
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
