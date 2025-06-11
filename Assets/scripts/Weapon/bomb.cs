using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bomb : WeaponBase
{
    public GameObject disapearparticle;
    public GameObject damagetex;
    public float damagetexcorecfactor;
    public int damage;
    public override void Attack()
    {
        base.Attack();
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        if (cd <= 0 && enemysin.Count != 0)
        {
            Instantiate(disapearparticle, transform.position, Quaternion.identity);
            for (int i = 0; i < enemysin.Count; i++)
            {
                enemysin[i].GetComponent<EnemyBase>().health -= damage;
                GameObject tex = Instantiate(damagetex, enemysin[i].transform.position + new Vector3(Random.Range(-damagetexcorecfactor, damagetexcorecfactor), Random.Range(-damagetexcorecfactor, damagetexcorecfactor), 0), Quaternion.identity);
                tex.GetComponentInChildren<TMP_Text>().text = damage.ToString();
            }
            Destroy(gameObject);
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
