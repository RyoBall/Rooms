using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    [Header("GetChip")]
    [SerializeField] private GameObject backpackpanel;
    public List<GameObject> BulletEffectChips;
    public List<GameObject> GlobalChips;
    public List<GameObject> BulletEnhanceChips;
    public List<GameObject> BulletChips;
    public Dictionary<int, List<GameObject>> chipsDic = new Dictionary<int, List<GameObject>>();
    public List<RectTransform> backpacktrans;
    public GameObject chipGetButton;
    public GameObject chipGetButtonParent;
    //�������
    public RectTransform middleScreen;
    public UnityEvent<int, int> OnChipClicked;
    [Header("GameState")]
    public GameState currentState;
    public enum GameState { UIPause, InFight, Normal, Rolling };
    public int currentlevel;
    [Header("UI")]
    public Action UIExit;
    public Action UIEnter;
    public bool exit;
    [Header("GetReplacement")]
    public List<GameObject> Segments;//ͨ��Segment����ķ����RoomID�����б��ȡSegment
    [Header("����")]
    public List<RectTransform> buttonpacktrans;
    public int backpackcount;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        UIEnter += () => exit = false;
        UIEnter += () => currentState = GameState.UIPause;
        UIExit += () => exit = true;
        UIExit += () => currentState = GameState.Normal;
        InitDic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetChipButton(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.K) && currentState != GameState.InFight && currentState != GameState.Rolling)
        {
            if (exit)
                UIEnter.Invoke();
            else
                UIExit.Invoke();
        }
    }
    void InitDic()
    {
        chipsDic.Add(1, BulletEffectChips);
        chipsDic.Add(2, GlobalChips);
        chipsDic.Add(3, BulletEnhanceChips);
    }
    //�Լ��޸ģ�
    public GameObject GetChip(int type, int order)
    {
        GameObject ins = null;
        switch (type)
        {
            //1:���� 2��ȫ�� 3������ 4:����
            case 1:
                ins = Instantiate(BulletEffectChips[order], backpackpanel.transform);
                //ins = Instantiate(BulletEffectChips[order], middleScreen);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 2:
                ins = Instantiate(GlobalChips[order], backpackpanel.transform);
                //ins = Instantiate(globalChips[order], middleScreen);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 3:
                ins = Instantiate(BulletEnhanceChips[order], backpackpanel.transform);
                //ins = Instantiate(BulletEnhanceChips[order], middleScreen);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
        }
        ins.GetComponent<RectTransform>().DOAnchorPos(backpacktrans[backpackcount].position, 1);
        return ins;
    }

    //�������ɸ����ѡ���ģ��
    public void ShowChipAndButton(int type, int order, RectTransform middleScreen, Transform parent)
    {
        GameObject ins;
        OnChipClicked.AddListener(AfterChooseChip);
        switch (type)
        {
            //1:���� 2��ȫ�� 3������ 4:����
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
        //�󶨸���
        ins.transform.SetParent(parent);
        //�󶨰�ť�¼�
        Button btn = gameObject.AddComponent<Button>();
        btn.onClick.AddListener(() => OnChipClicked?.Invoke(type, order));
    }

    //ѡ����ɾ��ѡ��ģ�飬����ģ��
    public void AfterChooseChip(int type, int order)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        GetChip(type, order);
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
            //1:���� 2��ȫ�� 3������ 4:����
            case 1:
                ins = Instantiate(BulletEffectChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                break;
            case 2:
                ins = Instantiate(GlobalChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                break;
            case 3:
                ins = Instantiate(BulletEnhanceChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
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
}
