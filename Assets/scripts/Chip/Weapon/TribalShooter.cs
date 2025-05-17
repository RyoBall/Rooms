using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribalShooter : shooter
{
    public override void shoot()
    {
        GameObject ins;
        Vector3 angle=Quaternion.LookRotation(dir).eulerAngles;
        Vector3 upshootdir=(Quaternion.Euler(angle + new Vector3(20, 0, 0)) * Vector3.forward).normalized;
        Debug.Log(angle);
        Debug.Log(upshootdir);
        Vector3 downshootdir=(Quaternion.Euler(angle - new Vector3(20, 0, 0)) * Vector3.forward).normalized;
        ins = Instantiate(bullet, transform.position, Quaternion.identity);
        InitBullet(ins.GetComponent<bullet>(), dir);
        ins = Instantiate(bullet, transform.position, Quaternion.identity);
        InitBullet(ins.GetComponent<bullet>(), upshootdir);
        ins = Instantiate(bullet, transform.position, Quaternion.identity);
        InitBullet(ins.GetComponent<bullet>(), downshootdir);
    }
    void InitBullet(bullet ins,Vector3 dir) 
    {
        ins.GetComponent<bullet>().dir = dir;
        ins.GetComponent<bullet>().attack = AttackCount();
        ins.GetComponent<bullet>().dad = this;
        ins.GetComponent<bullet>().speedfactor = speedfactor;
    }

    public override void Attack()
    {
        base.Attack();
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

    public override IEnumerator doubleroutine()
    {
        return base.doubleroutine();
    }
}
