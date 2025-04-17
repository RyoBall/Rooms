using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGeneratorController : MonoBehaviour
{
    public static enemyGeneratorController instance;
    public Transform t1;
    public Transform t3;//用小键盘数字的位置代指方位
    public Transform t7;
    public GameObject enemyGenerator;
    public float Correctionfactor;
    public float cd;
    public float cdm;
    public float fightTime;
    public float fightTimem;
    public bool inend;//最终阶段
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CDCount();
        FightTimeCount();
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
        if (cd <= 0&&fightTime>=0) 
        {
            cd = cdm;
            Generate(3);
        }
    }
    void FightTimeCount() 
    {
        if (fightTime >= 0) 
        {
        fightTime -= Time.deltaTime;
        }
        if (fightTime <= fightTimem - 60&&!inend) 
        {
            inend=true;
            cdm = cdm / 1.25f;
        }
        if (fightTime <= 0) 
        {
            exit();
        }
    }
    public void Init() 
    {
        fightTime=90f;
        cdm = cdm * 1.25f;
        inend = false;
        cd = 0;
    }
    void exit() 
    {
        level++;
        Player.instance.transform.DOMove(Player.instance.targetRoom.position,.5f);
        Player.instance.targetRoom.GetComponent<RoomBase>().Removefog();
    }
}
