using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;
using System.Collections;
using UnityEngine.Events;
public class segment : MonoBehaviour
{
    public static segment instance;
    public RectTransform here;
    [Header("轮盘设置")]
    public const int segmentcount = 12;
    public List<GameObject> segmentparts = new List<GameObject>();
    [SerializeField]public List<Image> segmentImages = new List<Image>();
    [Header("旋转属性")]
    public float rotatespeed;
    public float rotatespeedm;
    public float rotatespeedcorecfactor;
    public float downspeed;
    [Header("杂项")]
    public UnknownRoom targetroom;
    [SerializeField]private RectTransform Enter;
    [SerializeField]private RectTransform Exit;
    //public GameObject replacePrefab;
    public Image replaceImage;
    [SerializeField]private bool enter;
    [SerializeField]private bool readytoroll;
    public UnityEvent<int> OnSegmentClicked; // 点击事件
    public bool isNewRoom = false;
    void Start()
    {
        instance = this;
        here = GetComponent<RectTransform>();
        gameManager.instance.UIEnter += UIEnter;
        gameManager.instance.UIExit += UIExit;
    }
    private void Update()
    {
        if (readytoroll&&targetroom!=null&&gameManager.instance.currentState==gameManager.GameState.Rolling) 
        {
            readytoroll = false;
            Startrotate();
        }
        rotatehere();
    }
    private void Startrotate() 
    {
        rotatespeed = Random.Range(rotatespeedm - rotatespeedcorecfactor, rotatespeedm + rotatespeedcorecfactor);
        float waittime = rotatespeed / downspeed;
        startchec(waittime+.2f);
    }
    public void rotatehere() //转动
    {
        if(rotatespeed>=0)
        here.rotation = Quaternion.Euler(0, 0, here.localEulerAngles.z + Time.deltaTime * rotatespeed);
        if (rotatespeed >= 0)
            rotatespeed -= downspeed * Time.deltaTime;
    }
    public void GenerateWheel()
    {
        //OnSegmentClicked.AddListener(ReplaceSegmentPart);
        ClearWheel();
        float currentAngle = 0f;
        for (int i = 0; i < segmentcount; i++)
        {
            float segmentAngle = 360f / segmentcount;
            CreateSegment(i, currentAngle, segmentAngle);
            //用于替换轮盘块
            currentAngle += segmentAngle;
        }
    }

    /*public void ReplaceSegmentPart(int i)
    {
        //这里需要知道走廊是哪些数字,isnewroom是在清除走廊时为true
        if(i == 0 && !isNewRoom)
        {
            return;
        }
        else if (isNewRoom)
        {
            return;
        }
        StartCoroutine(ShowWheel());
    }*/

    IEnumerator ShowWheel()
    {
        GenerateWheel();
        yield return new WaitForSeconds(1);
        UIExit();
    }

    void CreateSegment(int index, float startAngle, float angle)
    {
        GameObject segment = Instantiate(segmentparts[index % segmentparts.Count], transform.position, Quaternion.identity);
        segment.transform.SetParent(transform);
        segment.GetComponent<segmentpart>().i=index;
        RectTransform rect = segment.GetComponent<RectTransform>();
        // 配置Image组件
        Image img = segment.GetComponent<Image>();
        // 设置旋转
        rect.localRotation = Quaternion.Euler(0, 0, -startAngle);
        //Button btn = segment.AddComponent<Button>();
        //btn.onClick.AddListener(() => OnSegmentClicked?.Invoke(index));
        segmentImages.Add(img);
    }
    public void ClearWheel()
    {
        here.rotation = Quaternion.Euler(0, 0, 0);
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        segmentImages.Clear();
    }

    public void UIEnter()
    {
        GenerateWheel();
        readytoroll = true;
        transform.parent.GetComponent<RectTransform>().DOAnchorPosX(-82.5f, .8f);
    }
    public void UIExit() 
    {
        readytoroll = false;
        transform.parent.GetComponent<RectTransform>().DOAnchorPosX(82.5f, .8f);
    }
    public void startchec(float waittime)
    {
        StartCoroutine(checroutine(waittime));
    }
    IEnumerator checroutine(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        chec();
    }
    private void chec() 
    {
        segmentImages[((int)here.rotation.eulerAngles.z / 30) % 12].GetComponent<segmentpart>().Effect();
    }
    public void RemoveReplacementChosen() 
    {
        for(int i = 0; i < segmentImages.Count; i++) 
        {
            segmentImages[i].GetComponent<segmentpart>().Clickaction = null;
        }
    }
}