using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGeneratorController : MonoBehaviour
{
    public Transform t1;
    public Transform t3;//用小键盘数字的位置代指方位
    public Transform t7;
    public GameObject enemyGenerator;
    public float Correctionfactor;
    public float cd;
    public float cdm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CDCount();
    }
    void Generate(int num) 
    {
       Vector3 position = new Vector3(Random.Range(t1.position.x,t3.position.x),Random.Range(t1.position.y,t7.position.y),0);
       for(int i = 0; i < num; i++) 
       {
            Instantiate(enemyGenerator, new Vector3(position.x+Random.Range(-Correctionfactor,Correctionfactor),position.y + Random.Range(-Correctionfactor, Correctionfactor),0), Quaternion.identity);
       }
    }
    void CDCount() 
    {
        cd -= Time.deltaTime;
        if (cd <= 0) 
        {
            cd = cdm;
            Generate(3);
        }
    }
}
