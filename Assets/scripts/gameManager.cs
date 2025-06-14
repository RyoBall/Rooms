using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    [Header("GetChip")]
    [SerializeField] private GameObject backpackpanel;
    public List<GameObject> BulletEffectChips;
    public List<GameObject> GlobalChips;
    public List<GameObject> BulletEnhanceChips;
    public List<GameObject> WeaponChips;
    public Dictionary<int, List<GameObject>> chipsDic = new Dictionary<int, List<GameObject>>();
    public List<RectTransform> backpacktrans;
    public GameObject chipGetButton;
    public GameObject chipGetButtonParent;
    [Header("GameState")]
    public GameState currentState;
    public enum GameState { UIPause, InFight, Normal, Rolling, Choosing };
    public int currentlevel;
    [Header("UI")]
    public Action UIExit;
    public Action UIEnter;
    public bool exit;
    [Header("GetReplacement")]
    public List<GameObject> Segments;//通过Segment代表的房间的RoomID访问列表获取Segment
    [Header("杂项")]
    public List<RectTransform> buttonpacktrans;
    public int backpackcount;
    [Header("初始化芯片")]
    public List<ChipBase> StartChips;
    [Header("不随场景销毁的物体")]
    public List<GameObject> DontDestroyObjs;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        UIEnter += () => exit = false;
        UIEnter += () => currentState = GameState.UIPause;
        UIExit += () => exit = true;
        UIExit += () => currentState = GameState.Normal;
        InitDic();
        DontDestroy();
    }
    private void Start()
    {
        InitChip();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetChipButton(1, 0, 0);
            ChoosePanel.instance.Enter();
        }
        if (Input.GetKeyDown(KeyCode.K) && (currentState == GameState.UIPause || currentState == GameState.Normal))
        {
            if (exit)
                UIEnter.Invoke();
            else
                UIExit.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Y))
            SceneManager.LoadScene("ReLoad");
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
            StartChips[i].entereffect(SkillPanel.instance.transform.GetChild(i).gameObject);
        }
    }
    public GameObject GetChip(int type, int order)
    {
        GameObject ins = null;
        switch (type)
        {
            //1:武器 2：全局 3：增益 4:特殊
            case 1:
                ins = Instantiate(BulletEffectChips[order], backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 2:
                ins = Instantiate(GlobalChips[order], backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 3:
                ins = Instantiate(BulletEnhanceChips[order], backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 4:
                ins = Instantiate(WeaponChips[order], backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
        }
        ins.GetComponent<RectTransform>().DOAnchorPos(backpacktrans[backpackcount].position, 1);
        return ins;
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
        if (ins.GetComponentInChildren<occupy>() != null)
        {
            Destroy(ins.GetComponent<occupy>());
        }
        insscript = chipbutton.AddComponent<GetChipBase>();
        insscript.type = type;
        insscript.order = order;
    }
    public void GetReplacementInReward(GameObject segment)
    {
        GetReplacement(segment, SegmentBag.instance.segmentsnum++);
    }
    public void GetReplacement(GameObject segment, int i)
    {
        GameObject replacement = Instantiate(SegmentBag.instance.replacement, SegmentBag.instance.Positions[i].position, Quaternion.identity, SegmentBag.instance.transform);
        replacement.GetComponent<Replacement>().segmentpart = segment;
        replacement.GetComponent<Replacement>().ID = i;
        replacement.GetComponent<Image>().color = segment.GetComponent<Image>().color;
    }
    void DontDestroy()
    {
        foreach(GameObject obj in DontDestroyObjs)
        DontDestroyOnLoad(obj);
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
