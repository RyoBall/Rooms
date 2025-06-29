using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBase : MonoBehaviour
{
    public float costs;
    public float level=1;
    private SpriteRenderer render;
    public Rigidbody2D rb;
    public Vector2 dir;
    public float speed;
    public float normalspeed;
    public float health;
    public float healthm;
    public GameObject deadparticle;
    public GameObject exp;
    public float CorrectingFactor;
    public int dropExpNum;
    public float attack;
    [SerializeField] protected float cd;
    [SerializeField] protected float cdm;
    [Header("state")]
    public float icytime;
    public bool icyResistence=false;
    public bool isboss;
    [SerializeField] protected float RepelResistance = 1;
    [SerializeField] protected GameObject bullet;
    // Start is called before the first frame update
    public Action<bullet> attackedAction = null;
    public virtual void Start()
    {
        healthm = health;   
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        attackedAction += AttackedAction;
        normalspeed = speed;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        move();
        if (health <= 0)
            Dead();
        CDCount();
        icytimecount();
        RecoverSpeed();
    }
    void RecoverSpeed()
    {
        if (speed < normalspeed)
            speed += Time.deltaTime * 5f;
        if (speed > 0)
            speed = normalspeed;
    }
    protected virtual void CDCount()
    {
        if (cd > 0 && icytime <= 0)
            cd -= Time.deltaTime;
    }
    public virtual void move()
    {
        if (icytime <= 0)
        {
            dir = -new Vector2(transform.position.x - Player.instance.transform.position.x, transform.position.y - Player.instance.transform.position.y);
            dir = dir.normalized;
            rb.velocity = speed * dir;
        }
        else 
        {
            if (!icyResistence)
                rb.velocity = Vector2.zero;
        }
    }
    public virtual void Dead()
    {
        enemyGeneratorController.instance.Enemys.Remove(gameObject);
        Instantiate(deadparticle, transform.position, Quaternion.identity);
        expdrop(dropExpNum);
        Destroy(gameObject);
    }
    void icytimecount()
    {
        if (icytime > 0)
        {
            icytime -= Time.deltaTime;
        }
    }
    public virtual void OnTriggerStay2D(Collider2D collision)//touch 
    {
        if (collision.tag == "Player" && icytime <= 0 && cd <= 0)
        {
            cd = cdm;
            Player.instance.Attacked(attack);
        }
    }
    public void expdrop(int nums)
    {
        for (int i = 0; i < nums; i++)
        {
            GameObject Exp=Instantiate(exp, transform.position + new Vector3(Random.Range(-CorrectingFactor, CorrectingFactor), Random.Range(-CorrectingFactor, CorrectingFactor), 0), Quaternion.identity);
            enemyGeneratorController.instance.exps.Add(Exp);
        }
    }
    protected void AttackedAction(bullet source)
    {
        attackanim();
        Repel(source.dad.repelforce);
    }
    protected void attackanim()
    {
        render.color = Color.red;
        StartCoroutine(attackroutine());
    }
    IEnumerator attackroutine()
    {
        yield return new WaitForSeconds(0.1f);
        render.color = Color.white;
    }
    private void Repel(float repelforce)
    {
        if(!isboss)
        speed = -repelforce/RepelResistance*2;
    }
}
