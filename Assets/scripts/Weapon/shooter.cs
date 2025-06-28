using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shooter : WeaponBase
{
    public GameObject bullet;
    public int doubleattackpoint;
    public float speedfactor;
    public float repelforce;
    public Collider2D RangeChecer;
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
            StartCoroutine(doubleroutine(doubleattacklevel));
        }
    }
    public virtual IEnumerator doubleroutine(float doubleattackpoint) 
    {
        yield return new WaitForSeconds(.05f);
        if (doubleattackpoint > 0) 
        {
            shoot();
            Debug.Log(doubleattackpoint);
            StartCoroutine(doubleroutine(doubleattackpoint-1));
        }
    }
    public virtual void shoot() 
    {
        GameObject ins = Instantiate(bullet, transform.position, Quaternion.identity);
        ins.GetComponent<bullet>().dir = dir;
        ins.GetComponent<bullet>().attack=AttackCount();
        ins.GetComponent<bullet>().dad=this;
    }
    public override void DIR()
    {
        base.DIR();
    }

    public override void Start()
    {
        base.Start();
        RangeChecer = GetComponent<Collider2D>();
    }

    public override void Update()
    {
        base.Update();
        if (gameManager.instance.currentState == gameManager.GameState.InFight) 
        {
            RangeChecer.enabled = true;
        }
        else
        {
            RangeChecer.enabled = false;
        }
    }
}
