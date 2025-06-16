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
    public List<GameObject> enemyGenerators;
    public List<EnemyBase> enemyGeneratorsScripts;
    private float AllWeights = 0;
    public float Correctionfactor;
    public float cd;
    public float cdm;
    public float startcdm;
    public float fightTime;
    public float fightTimem;
    public bool inend;//最终阶段
    public int level;
    public bool bossfighting;
    public Action ExitAction = null;
    public List<GameObject> Enemys = new List<GameObject>();
    public List<GameObject> Bosses = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < enemyGeneratorsScripts.Count; i++)
        {
            AllWeights += 1 / enemyGeneratorsScripts[i].costs;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FightTest();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FightEndTest();
        }
        if (gameManager.instance.currentState == gameManager.GameState.InFight)
        {
            CDCount();
            FightTimeCount();
        }
    }
    public void FightTest()
    {
        Player.instance.transform.DOMove(foggylevel.position, 1);
        Init(true);
    }
    public void FightEndTest()
    {
        fightTime = 0;
    }
    void Generate(float costs)
    {
        Vector3 position = new Vector3(Random.Range(t1.position.x, t3.position.x), Random.Range(t1.position.y, t7.position.y), 0);
        float currentcost = 0;
        while (currentcost < costs)
        {
            int currentenemyPointer = 0;//记录当前所指向的怪物
            float randomweight = Random.Range(0, AllWeights);
            float currentweight = 1 / enemyGeneratorsScripts[0].costs;//在随机权重中当前记载的权重
            while (currentweight < randomweight)
            {
                currentenemyPointer++;
                currentweight += 1/enemyGeneratorsScripts[currentenemyPointer].costs;
            }
            Instantiate(enemyGenerators[currentenemyPointer], new Vector3(position.x + Random.Range(-Correctionfactor, Correctionfactor), position.y + Random.Range(-Correctionfactor, Correctionfactor), 0), Quaternion.identity);
            currentcost += enemyGeneratorsScripts[currentenemyPointer].costs;
        }
    }
    void CDCount()
    {
        cd -= Time.deltaTime;
        if (cd <= 0 && fightTime >= 0)
        {
            cd = cdm;
            Generate(15 + level * 5);
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
            if(!bossfighting)
            exit();
            else 
            {
                Player.instance.health -= 10 * Time.deltaTime;
            }
        }
    }
    public void Init(bool isboss)
    {
        gameManager.instance.currentState = gameManager.GameState.InFight;
        if (!isboss)
        {
            cdm = startcdm;
            cd = 0;
            fightTime = 60f;
            StartCoroutine(FightHard(fightTime - 30f));
            cd = 0;
        }
        else
        {
            bossfighting = true;
            cdm=20000;
            cd = cdm;
            fightTime = 120f;
            Instantiate(Bosses[gameManager.instance.currentlevel - 1], transform.position, Quaternion.identity);
        }
    }
    public void exit()
    {
        if (level <= 2)
            level++;
        if (Player.instance.targetRoom != null)
        {
            Player.instance.targetRoom.GetComponent<RoomBase>().Removefog();
            Player.instance.targetRoom.GetComponent<RoomBase>().GetComponent<SpriteRenderer>().color = Player.instance.targetRoom.GetComponent<RoomBase>().Startcolor;
        }
        Player.instance.targetRoom.GetComponent<RoomBase>().EnterAction?.Invoke();
        Player.instance.targetRoom = null;
        ExitAction?.Invoke();
        for (int i = 0; i < Enemys.Count; i++)
        {
            Destroy(Enemys[i]);
        }
        Enemys.Clear();
        gameManager.instance.currentState = gameManager.GameState.Normal;
        Debug.Log(1);
        Player.instance.rb.velocity = Vector2.zero;
    }
    IEnumerator FightHard(float time)
    {
        yield return new WaitForSeconds(time);
        cdm = startcdm / 1.25f;
    }
}
