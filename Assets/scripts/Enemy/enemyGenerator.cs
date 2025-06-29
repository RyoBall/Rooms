using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public float cd;
    public float cdm;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        cd = cdm;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null) 
        {
            cdCount();
        }
        if (gameManager.instance.currentState != gameManager.GameState.InFight)
            Destroy(gameObject);
        if (cd <= 0) 
        {
            GameObject Enemy=Instantiate(enemy, transform.position, transform.rotation);
            Enemy.GetComponent<EnemyBase>().level = level;
            enemyGeneratorController.instance.Enemys.Add(Enemy);
            Destroy(gameObject);   
        }
    }
    void cdCount() 
    {
        cd -= Time.deltaTime;
    }
}
