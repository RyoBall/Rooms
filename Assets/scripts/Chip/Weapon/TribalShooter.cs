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
        Vector3 upshootdir1=(Quaternion.Euler(angle + new Vector3(40, 0, 0)) * Vector3.forward).normalized;
        Vector3 downshootdir=(Quaternion.Euler(angle - new Vector3(20, 0, 0)) * Vector3.forward).normalized;
        Vector3 downshootdir1=(Quaternion.Euler(angle - new Vector3(40, 0, 0)) * Vector3.forward).normalized;
        ins = Instantiate(bullet, transform.position, Quaternion.identity);
        InitBullet(ins.GetComponent<bullet>(), dir);
        ins = Instantiate(bullet, transform.position, Quaternion.identity);
        InitBullet(ins.GetComponent<bullet>(), upshootdir);
        ins = Instantiate(bullet, transform.position, Quaternion.identity);
        InitBullet(ins.GetComponent<bullet>(), downshootdir);
        ins = Instantiate(bullet, transform.position, Quaternion.identity);
        InitBullet(ins.GetComponent<bullet>(), upshootdir1);
        ins = Instantiate(bullet, transform.position, Quaternion.identity);
        InitBullet(ins.GetComponent<bullet>(), downshootdir1);
    }
    void InitBullet(bullet ins,Vector3 dir) 
    {
        ins.GetComponent<bullet>().dir = dir;
        ins.GetComponent<bullet>().attack = AttackCount();
        ins.GetComponent<bullet>().dad = this;
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

    public override IEnumerator doubleroutine(float doubleattackpoint)
    {
        return base.doubleroutine(doubleattackpoint);
    }
}
