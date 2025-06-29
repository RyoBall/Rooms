using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    [Header("GetChip")]
    public List<GameObject> BulletEffectChips;
    public List<GameObject> GlobalChips;
    public List<GameObject> BulletEnhanceChips;
    public List<GameObject> WeaponChips;
    public Dictionary<int, List<GameObject>> chipsDic = new Dictionary<int, List<GameObject>>();
    public List<RectTransform> backpacktrans;
    public int chipnums = 0;
    public GameObject chipGetButton;
    public GameObject chipGetButtonParent;
    [Header("GameState")]
    public GameState currentState;
    public enum GameState { UIPause, InFight, Normal, Rolling, Choosing };
    public static int currentlevel=1;
    [Header("UI")]
    public static Action BagUIExit;
    public static Action BagUIEnter;
    public static Action SegUIExit;
    public static Action SegUIEnter;
    public bool Bagexit;
    public bool Segexit;
    [SerializeField] private AudioSource UIaudioplayer;
    [Header("GetReplacement")]
    public List<GameObject> Segments;//通过Segment代表的房间的RoomID访问列表获取Segment
    [Header("杂项")]
    public List<RectTransform> buttonpacktrans;
    public int backpackcount;
    [Header("初始化芯片")]
    public List<ChipBase> StartChips;
    public bool initfinish = false;
    [Header("不随场景销毁的物体")]
    public List<GameObject> DontDestroyObjs;
    public static List<GameObject> NotDestroyObjs=new List<GameObject>();
    [Header("芯片音效储存")]
    public AudioClip enterclip;
    public AudioClip exitclip;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        BagUIEnter += () => Bagexit = false;
        SegUIEnter += () => Segexit = false;
        BagUIEnter += () => currentState = GameState.UIPause;
        SegUIEnter += () => currentState = GameState.UIPause;
        BagUIExit += () => Bagexit = true;
        SegUIExit += () => Segexit = true;
        BagUIExit += () => currentState = GameState.Normal;
        SegUIExit += () => currentState = GameState.Normal;
        InitDic();
        DontDestroy();
    }
    private void Start()
    {
        chipGetButtonParent = ChoosePanel.instance.gameObject;
        InitChip();
        StartCoroutine(BlackExit(0.5f,1));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.instance.currentState == gameManager.GameState.InFight && (!Bagexit || !Segexit))
        {
            BagUIExit.Invoke();
            SegUIExit.Invoke();
            currentState = GameState.InFight;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && (currentState == GameState.UIPause || currentState == GameState.Normal))
        {
            if (Bagexit)
            {
                if (!Segexit) 
                {
                    SegUIExit.Invoke();
                }
                BagUIEnter.Invoke();
                UIaudioplayer.Play();
            }
            else 
            {
                BagUIExit.Invoke();
                Blacker.instance.Exit();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && (currentState == GameState.UIPause || currentState == GameState.Normal))
        {
            if (Segexit) 
            {
                if (!Bagexit)
                    BagUIExit.Invoke();
                SegUIEnter.Invoke();
                UIaudioplayer.Play();
            }
            else 
            {
                SegUIExit.Invoke();
                Blacker.instance.Exit();
            }
        }
    }
    void InitDic()
    {
        chipsDic.Add(1, BulletEffectChips);
        chipsDic.Add(2, GlobalChips);
        chipsDic.Add(3, BulletEnhanceChips);
        chipsDic.Add(4, WeaponChips);
    }
    //稍加修改（
    void InitChip()
    {
        for (int i = 0; i < StartChips.Count; i++)
        {
            StartChips[i].entereffect(SkillPanel.instance.MainPanel.transform.GetChild(i + 1).gameObject);
            StartChips[i].StartPosition = backpacktrans[chipnums]; 
            chipnums++;
        }
        initfinish = true;
    }
    public GameObject GetChip(int type, int order)
    {
        GameObject ins = null;
        switch (type)
        {
            //1:武器 2：全局 3：增益 4:特殊
            case 1:
                ins = Instantiate(BulletEffectChips[order], backpacktrans[backpackcount]);
                ins.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                ins.GetComponent<ChipBase>().StartPosition = backpacktrans[chipnums];
                backpackcount++;
                break;
            case 2:
                ins = Instantiate(GlobalChips[order], backpacktrans[backpackcount]);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                ins.GetComponent<ChipBase>().StartPosition = backpacktrans[chipnums];
                backpackcount++;
                break;
            case 3:
                ins = Instantiate(BulletEnhanceChips[order], backpacktrans[backpackcount]);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                ins.GetComponent<ChipBase>().StartPosition = backpacktrans[chipnums];
                backpackcount++;
                break;
            case 4:
                ins = Instantiate(WeaponChips[order], backpacktrans[backpackcount]);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                ins.GetComponent<ChipBase>().StartPosition = backpacktrans[chipnums];
                backpackcount++;
                break;
        }
        return ins;
    }
    IEnumerator BlackExit(float starttime, float time)
    {
        yield return new WaitForSeconds(starttime);
        Blacker.instance.Exit(time);//黑幕落下
    }
    public void GetChipButton(int type, int order, int position)
    {
        GameObject chipbutton = Instantiate(chipGetButton, buttonpacktrans[position].position, Quaternion.identity, chipGetButtonParent.transform);
        ChoosePanel.instance.choice.Add(chipbutton);
        chipbutton.GetComponent<RectTransform>().position = buttonpacktrans[position].position;
        GameObject ins;
        GetChipBase insscript;
        switch (type)
        {
            //1:武器 2：全局 3：增益 4:特殊
            case 1:
                ins = Instantiate(BulletEffectChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                break;
            case 2:
                ins = Instantiate(GlobalChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                break;
            case 3:
                ins = Instantiate(BulletEnhanceChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                break;
            case 4:
                ins = Instantiate(WeaponChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                break;
            default:
                ins = null;
                break;
        }
        Destroy(ins.GetComponent<ChipBase>());
        Destroy(ins.GetComponent<Collider2D>());
        if (ins.GetComponentInChildren<occupy>() != null)
        {
            Destroy(ins.GetComponentInChildren<occupy>());
            Destroy(ins.GetComponentInChildren<Collider2D>());
        }
        ins.transform.localScale = new Vector3(.5f,.5f,1);
        insscript = chipbutton.AddComponent<GetChipBase>();
        insscript.type = type;
        insscript.order = order;
    }
    public void GetReplacementInReward(GameObject segment)
    {
        GetReplacement(segment, ReplacementBag.instance.segmentsnum);
    }
    public void GetReplacement(GameObject segment, int i)
    {
        ReplacementBag.instance.segmentsnum++;
        GameObject replacement = Instantiate(ReplacementBag.instance.replacement, ReplacementBag.instance.segmentBags[i / 21].Positions[i%21].position, Quaternion.identity, ReplacementBag.instance.transform);
        replacement.GetComponent<Replacement>().segmentpart = segment;
        replacement.GetComponent<Replacement>().ID = i;
        replacement.GetComponent<Image>().sprite = segment.GetComponent<Image>().sprite;
    }
    void DontDestroy()
    {
        foreach (GameObject obj in DontDestroyObjs) 
        {
            DontDestroyOnLoad(obj);
            NotDestroyObjs.Add(obj);
        }
    }
    //用于生成给玩家选择的模块
    /*public void ShowChipAndButton(int type, int order, RectTransform middleScreen, Transform parent)
    {
        GameObject ins;
        OnChipClicked.AddListener(AfterChooseChip);
        switch (type)
        {
            //1:武器 2：全局 3：增益 4:特殊
            case 1:
                ins = Instantiate(BulletEffectChips[order], middleScreen);
                break;
            case 2:
                ins = Instantiate(GlobalChips[order], middleScreen);
                break;
            case 3:
                ins = Instantiate(BulletEnhanceChips[order], middleScreen);
                break;
            default:
                ins = null;
                break;
        }
        //绑定父级
        ins.transform.SetParent(parent);
        //绑定按钮事件
        Button btn = gameObject.AddComponent<Button>();
        btn.onClick.AddListener(() => OnChipClicked?.Invoke(type, order));
    }

    //选定后删除选择模块，加载模块
    public void AfterChooseChip(int type, int order)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        GetChip(type, order);
    }*/
}
