using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Boss : EnemyBase
{
    [SerializeField]private float skillcd;
    private float skillcdm;
    private bool dashing;
    [Header("dash")]
    [SerializeField] private GameObject DashRange;
    [SerializeField] private float offset;
    public override void Dead()
    {
        base.Dead();
    }

    public override void move()
    {
        if (!dashing)
        {
            base.move();
        }
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }

    public override void Start()
    {
        base.Start();
        health = 1500;
        attack = 10;
        cdm = 1;
        skillcdm = 10;
    }

    public override void Update()
    {
        base.Update();
        SkillCDCount();
    }

    protected override void CDCount()
    {
        base.CDCount();
    }
    public virtual Vector2 DIR()
    {
        Vector2 dir = new UnityEngine.Vector2(Player.instance.transform.position.x - transform.position.x, Player.instance.transform.position.y - transform.position.y);
        dir = dir.normalized;
        return dir;
    }
    public void SkillCDCount() 
    {
        skillcd -= Time.deltaTime;
        if (skillcd <= 0) 
        {
            skillcd = skillcdm;
            Skill();
        }
    }
    void Skill()
    {
        int random=Random.Range(0,1);
        switch (random) 
        {
            case 0:
                Dash();
                break;
            case 1:
                Shoot();
                break;
        }
    }
    #region DashSkill
    void Dash()
    {
        StartCoroutine(DashCourotine());
    }
    IEnumerator DashCourotine()
    {
        dashing = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = DIR();
        GameObject range = Instantiate(DashRange, transform.position + new Vector3(dir.x, dir.y, 0) * offset, UnityEngine.Quaternion.Euler(new Vector3(0,0,Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg)));
        yield return new WaitForSeconds(1.5f);
        DashSkill(dir);
    }
    void DashSkill(Vector2 dir)
    {
        StartCoroutine(FinishDash());
        rb.velocity = dir * speed / 0.7f * 4;
        attack = attack * 4;
    }
    IEnumerator FinishDash() 
    {
        yield return new WaitForSeconds(1f);
        dashing = false;
        attack = attack / 4;
    }
    #endregion
    #region ShootSkill
    void Shoot() 
    {
           
    }
    #endregion
}
