using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class WeaponBase : MonoBehaviour
{
    public float cd;
    public float cdm;
    public List<GameObject> enemysin;
    public UnityEngine.Vector2 dir;
    public float range;
    public GameObject closestenemy;
    public CircleCollider2D rangechecer;
    [Header("attack")]
    public float attack;
    public float attackfactor;
    [Header("bulleteffect")]
    public int doubleattacklevel;
    public int icyattacklevel;
    public int bumattacklevel;
    public int bombattacklevel;
    public int heavyattacklevel;
    public int fireattacklevel;
    public GameObject bomber;
    [Header("AttackBuff")]
    public Action<EnemyBase, bullet> AttackAction=null;
    public GameObject FireParticle;
    public virtual void Start()
    {
        rangechecer=GetComponent<CircleCollider2D>();
        AttackAction += FireEffect;
        AttackAction += BombEffect;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        rangechecer.radius = range;
        Attack();
    }
    public int AttackCount() 
    {
       int finalattack = (int)(Player.instance.attack * attack * (1 + attackfactor + Player.instance.attackfactor));
        if (doubleattacklevel>0)
          finalattack= (int)(finalattack * 0.6f);
        if(heavyattacklevel>0)
          finalattack= (int)(finalattack*(1+heavyattacklevel));
        return finalattack;
    }
    public virtual void Attack() 
    {
        ;
    }
    public virtual void DIR() 
    {
        closestenemy = FindEnemy();
        if (closestenemy != null)
            dir = new UnityEngine.Vector2(closestenemy.transform.position.x - transform.position.x, closestenemy.transform.position.y - transform.position.y);
        else
            Debug.Log("noenemy");
            dir = dir.normalized;
    }
    public GameObject FindEnemy() 
    {
        float closestdistance=0;
        GameObject closest=null;
        for(int i = 0; i < enemysin.Count; i++) 
        {
            GameObject enemy = enemysin[i];
            if (i == 0) 
            {
                closest = enemy;
                closestdistance = (enemy.transform.position.x - transform.position.x) * (enemy.transform.position.x - transform.position.x) + (enemy.transform.position.y - transform.position.y) * (enemy.transform.position.y - transform.position.y);
            }
            else 
            {
                float distance= (enemy.transform.position.x - transform.position.x) * (enemy.transform.position.x - transform.position.x) + (enemy.transform.position.y - transform.position.y) * (enemy.transform.position.y - transform.position.y);
                if (distance < closestdistance) 
                {
                    closest=enemy;
                    closestdistance = distance;
                }
            }
        }
        return closest;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemysin.Add(collision.gameObject);
        }   
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemysin.Remove(collision.gameObject);
        }
    }
    public void FireEffect(EnemyBase target, bullet bullet)
    {
        if (fireattacklevel > 0)
            StartCoroutine(FireRoutine(target, bullet, 5));
    }
    IEnumerator FireRoutine(EnemyBase target, bullet bullet, float time)
    {
        if (time >= 0&&target!=null)
        {
            target.health -= bullet.attack * (0.1f + 0.1f * bullet.dad.fireattacklevel);
            GameObject tex = Instantiate(bullet.damagetex, target.transform.position + new Vector3(Random.Range(-bullet.damagetexcorecfactor, bullet.damagetexcorecfactor), Random.Range(-bullet.damagetexcorecfactor, bullet.damagetexcorecfactor), 0), Quaternion.identity);
            tex.GetComponentInChildren<TMP_Text>().text = (bullet.attack * (0.1f + 0.1f * bullet.dad.fireattacklevel)).ToString();
            Instantiate(FireParticle, target.transform.position + new Vector3(Random.Range(-bullet.damagetexcorecfactor, bullet.damagetexcorecfactor), Random.Range(-bullet.damagetexcorecfactor, bullet.damagetexcorecfactor), 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(1);
        if (time >= 0&&target!=null)
            StartCoroutine(FireRoutine(target, bullet, time - 1));
    }
    public void BombEffect(EnemyBase target, bullet bullet) 
    {
        if (bombattacklevel > 0)
            StartCoroutine(BombRoutine(target,bullet,bombattacklevel));
    }
    IEnumerator BombRoutine(EnemyBase target, bullet bullet,int bombpoints)
    {
        yield return new WaitForSeconds(.05f);
        if (bombpoints > 0)
        {
            Debug.Log("bomb");
            GameObject bomb = Instantiate(bomber, target.transform.position, Quaternion.identity);
            bomb.GetComponent<bomb>().damage = (int)(attack * .3f);
            StartCoroutine(BombRoutine(target,bullet,bombpoints-1));
        }
    }
}
