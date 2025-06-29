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
    public float Acd;
    public float cdm;
    public float Acdm;
    public float startcdm;
    public float Astartcdm;
    public float fightTime;
    public float fightTimem;
    public bool inend;//最终阶段
    public int level;
    public bool bossfighting;
    public Action ExitAction = null;
    public Action EnterAction = null;
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
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FightTest();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
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
                currentweight += 1 / enemyGeneratorsScripts[currentenemyPointer].costs;
            }
            Instantiate(enemyGenerators[currentenemyPointer], new Vector3(position.x + Random.Range(-Correctionfactor, Correctionfactor), position.y + Random.Range(-Correctionfactor, Correctionfactor), 0), Quaternion.identity);
            currentcost += enemyGeneratorsScripts[currentenemyPointer].costs;
        }
    }
    void Generate(int type, int num, int level)
    {
        Vector3 position = new Vector3(Random.Range(t1.position.x, t3.position.x), Random.Range(t1.position.y, t7.position.y), 0);
        for (int i = 0; i < num; i++)
        {
            enemyGenerator enemy = Instantiate(enemyGenerators[type], new Vector3(position.x + Random.Range(-Correctionfactor, Correctionfactor), position.y + Random.Range(-Correctionfactor, Correctionfactor), 0), Quaternion.identity).GetComponent<enemyGenerator>();
            enemy.level = level;
        }
    }
    void CDCount()
    {
        cd -= Time.deltaTime;
        if (cd <= 0 && fightTime >= 0)
        {
            cd = cdm;
            switch (gameManager.currentlevel)
            {
                case 1:
                    switch (level)
                    {
                        case 1:
                            Generate(0, 4, 1);
                            break;
                        case 2:
                            Generate(0, 6, 2);
                            break;
                        case 3:
                            Generate(0, 6, 3);
                            break;
                        case 4:
                            Generate(0, 5, 3);
                            Generate(0, 5, 3);
                            break;
                        default:
                            Generate(0, 5, 3);
                            Generate(0, 5, 3);
                            break;
                    }
                    break;
                case 2:
                    switch (level)
                    {
                        case 1:
                            Generate(0, 4, 3);
                            break;
                        case 2:
                            Generate(0, 6, 3);
                            break;
                        case 3:
                            Generate(0, 8, 3);
                            break;
                        case 4:
                            Generate(0, 6, 3);
                            break;
                        case 5:
                            Generate(0, 10, 3);
                            break;
                        default:
                            Generate(0, 10, 3);
                            break;
                    }
                    break;
                case 3:
                    switch (level)
                    {
                        case 1:
                            Generate(1, 6, 3);
                            break;
                        case 2:
                            Generate(1, 8, 3);
                            break;
                        case 3:
                            Generate(1, 8, 3);
                            break;
                        case 4:
                            Generate(1, 8, 3);
                            break;
                        case 5:
                            Generate(1, 8, 3);
                            break;
                        case 6:
                            Generate(1, 10, 3);
                            break;
                        default:
                            Generate(1, 10, 3);
                            break;
                    }
                    break;
            }
            if (Astartcdm != 0)
            {
                Acd -= Time.deltaTime;
                if (Acd <= 0 && fightTime >= 0)
                {
                    Acd = Acdm;
                    switch (gameManager.currentlevel)
                    {
                        case 2:
                            switch (level)
                            {
                                case 1:
                                    Generate(1, 4, 1);
                                    break;
                                case 2:
                                    Generate(1, 6, 2);
                                    break;
                                case 3:
                                    Generate(1, 8, 3);
                                    break;
                                case 4:
                                    Generate(1, 6, 3);
                                    break;
                                case 5:
                                    Generate(1, 10, 3);
                                    break;
                                default:
                                    Generate(1, 10, 3);
                                    break;
                            }
                            break;
                        case 3:
                            switch (level)
                            {
                                case 1:
                                    Generate(2, 4, 1);
                                    break;
                                case 2:
                                    Generate(2, 6, 2);
                                    break;
                                case 3:
                                    Generate(2, 8, 3);
                                    break;
                                case 4:
                                    Generate(2, 6, 3);
                                    break;
                                case 5:
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    break;
                                case 6:
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    break;
                                default:
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    Generate(2, 2, 3);
                                    break;
                            }
                            break;
                    }
                }
            }
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
            if (!bossfighting)
                exit();
            else
            {
                Player.instance.health -= 10 * Time.deltaTime;
            }
        }
    }
    public void Init(bool isboss)
    {
        EnterAction?.Invoke();
        gameManager.instance.currentState = gameManager.GameState.InFight;
        if (!isboss)
        {
            cdm = startcdm;
            cd = 0;
            fightTime = 60f;
            StartCoroutine(FightHard(fightTime - 30f));
            switch (gameManager.currentlevel)
            {
                case 1:
                    Astartcdm = 0;
                    break;
                case 2:
                    switch (level)
                    {
                        case 1:
                            Astartcdm = 10;
                            break;
                        case 2:
                            Astartcdm = 10;
                            break;
                        case 3:
                            Astartcdm = 10;
                            break;
                        case 4:
                            Astartcdm = 5;
                            break;
                        case 5:
                            Astartcdm = 5;
                            break;
                    }
                    break;
                case 3:
                    if (level < 4)
                        Astartcdm = 10;
                    else
                        Astartcdm = 5;
                    break;
            }
            Acdm = Astartcdm;
            cd = 0;
        }
        else
        {
            bossfighting = true;
            cdm = 20000;
            cd = cdm;
            fightTime = 120f;
            Instantiate(Bosses[0], transform.position, Quaternion.identity);
        }
    }
    public void exit()
    {
        level++;
        if (Player.instance.targetRoom != null)
        {
            Player.instance.targetRoom.GetComponent<RoomBase>().Removefog();
            Player.instance.targetRoom.GetComponent<RoomBase>().GetComponent<SpriteRenderer>().color = Player.instance.targetRoom.GetComponent<RoomBase>().Startcolor;
        }
        Player.instance.targetRoom.GetComponent<RoomBase>().EnterAction?.Invoke();
        Player.instance.targetRoom = null;
        for (int i = 0; i < Enemys.Count; i++)
        {
            Destroy(Enemys[i]);
        }
        Enemys.Clear();
        gameManager.instance.currentState = gameManager.GameState.Normal;
        ExitAction?.Invoke();
        Player.instance.rb.velocity = Vector2.zero;
        Acdm = 0;
        Astartcdm = 0;
    }
    IEnumerator FightHard(float time)
    {
        yield return new WaitForSeconds(time);
        cdm = startcdm / 1.25f;
        Acdm = Astartcdm / 1.25f;
    }
}
