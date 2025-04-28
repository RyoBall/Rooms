using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float cd;
    public float cdm;
    public List<GameObject> enemysin;
    public UnityEngine.Vector2 dir;
    public float range;
    public GameObject closestenemy;
    [Header("attack")]
    public float attack;
    public float attackfactor;
    public virtual void Start()
    {
        GetComponent<CircleCollider2D>().radius = range;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Attack();
    }
    public int AttackCount() 
    {
       int finalattack = (int)(Player.instance.attack * attack * (1 + attackfactor + Player.instance.attackfactor));
        return finalattack;
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
    public virtual void Attack() 
    {
        ;
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
}
