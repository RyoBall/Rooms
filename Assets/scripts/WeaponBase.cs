using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float cd;
    public float cdm;
    public float range;
    public List<GameObject> enemysin;
    public UnityEngine.Vector2 dir;
    public float attack;
    public GameObject closestenemy;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }
    void DIR() 
    {
        closestenemy = FindEnemy();
        if (closestenemy != null)
            dir = new UnityEngine.Vector2(closestenemy.transform.position.x - transform.position.x, closestenemy.transform.position.y - transform.position.y);
        else
            Debug.Log("noenemy");
            dir = dir.normalized;
    }
    void shoot() 
    {
        if (cd > 0) 
        {
            cd -= Time.deltaTime;
        }
        if (cd <= 0&&enemysin.Count!=0) 
        {
            DIR();
            cd = cdm;
            GameObject shootbullet=Instantiate(bullet,transform.position, UnityEngine.Quaternion.identity);
            shootbullet.GetComponent<bullet>().dir = dir;
            shootbullet.GetComponent<bullet>().attack=attack;
        }
    }
    GameObject FindEnemy() 
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemysin.Add(collision.gameObject);
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemysin.Remove(collision.gameObject);
        }
    }
}
