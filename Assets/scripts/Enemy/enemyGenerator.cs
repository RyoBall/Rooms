using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public float cd;
    public float cdm;
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
        if (cd <= 0) 
        {
            GameObject Enemy=Instantiate(enemy, transform.position, transform.rotation);
            enemyGeneratorController.instance.Enemys.Add(Enemy);
            Destroy(gameObject);   
        }
    }
    void cdCount() 
    {
        cd -= Time.deltaTime;
    }
}
