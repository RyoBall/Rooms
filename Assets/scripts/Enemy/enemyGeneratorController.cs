using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyGeneratorController : MonoBehaviour
{
    public static enemyGeneratorController instance;
    public Transform t1;
    public Transform t3;//用小键盘数字的位置代指方位
    public Transform t7;
    public Transform foggylevel;
    public GameObject enemyGenerator;
    public float Correctionfactor;
    public float cd;
    public float cdm;
    public float startcdm;
    public float fightTime;
    public float fightTimem;
    public bool inend;//最终阶段
    public int level;
    public Action ExitAction;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            FightTest();
        }
        if (gameManager.instance.currentState==gameManager.GameState.InFight)
        {
            CDCount();
            FightTimeCount();
        }
    }
    public void FightTest() 
    {
        Player.instance.transform.DOMove(foggylevel.position, 1);
        Init();
    }
    void Generate(int num)
    {
        Vector3 position = new Vector3(Random.Range(t1.position.x, t3.position.x), Random.Range(t1.position.y, t7.position.y), 0);
        for (int i = 0; i < num; i++)
        {
            Instantiate(enemyGenerator, new Vector3(position.x + Random.Range(-Correctionfactor, Correctionfactor), position.y + Random.Range(-Correctionfactor, Correctionfactor), 0), Quaternion.identity);
        }
    }
    void CDCount()
    {
        cd -= Time.deltaTime;
        if (cd <= 0 && fightTime >= 0)
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
        if (fightTime <= 0)
        {
            exit();
        }
    }
    public void Init()
    {
        gameManager.instance.currentState = gameManager.GameState.InFight;
        fightTime = 60f;
        cdm = startcdm;
        StartCoroutine(FightHard(fightTime-30f));
        cd = 0;
    }
    void exit()
    {
        level++;
        Player.instance.targetRoom.GetComponent<RoomBase>().Removefog();
        Player.instance.targetRoom.GetComponent<RoomBase>().EnterAction.Invoke();
        Player.instance.targetRoom = null;
        ExitAction.Invoke();
        gameManager.instance.currentState = gameManager.GameState.Normal;
    }
    IEnumerator FightHard(float time) 
    {
        yield return new WaitForSeconds(time);
        cd = cdm / 1.25f;
    }
}
