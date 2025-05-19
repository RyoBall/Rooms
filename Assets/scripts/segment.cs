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
    [Header("��������")]
    public const int segmentcount = 12;
    public List<GameObject> segmentparts = new List<GameObject>();
    [SerializeField]private List<Image> segmentImages = new List<Image>();
    [Header("��ת����")]
    public float rotatespeed;
    public float rotatespeedm;
    public float rotatespeedcorecfactor;
    public float downspeed;
    [Header("����")]
    public UnknownRoom targetroom;
    public RectTransform Enter;
    public RectTransform Exit;
    public GameObject replacePrefab;
    public Image replaceImage;

    public UnityEvent<int> OnSegmentClicked; // ����¼�
    public bool isNewRoom = false;
    void Start()
    {
        instance = this;
        here = GetComponent<RectTransform>();
        GenerateWheel();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)&&targetroom!=null) 
        {
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
    public void rotatehere() //ת��
    {
        if(rotatespeed>=0)
        here.rotation = Quaternion.Euler(0, 0, here.localEulerAngles.z + Time.deltaTime * rotatespeed);
        if (rotatespeed >= 0)
            rotatespeed -= downspeed * Time.deltaTime;
    }
    public void GenerateWheel()
    {
        ClearWheel();
        OnSegmentClicked.AddListener(ReplaceSegmentPart);
        float currentAngle = 0f;
        for (int i = 0; i < segmentcount; i++)
        {
            float segmentAngle = 360f / segmentcount;
            CreateSegment(i, currentAngle, segmentAngle);
            //�����滻���̿�
            currentAngle += segmentAngle;
        }
    }

    public void ReplaceSegmentPart(int i)
    {
        //������Ҫ֪����������Щ����,isnewroom�����������ʱΪtrue
        if(i == 0 && !isNewRoom)
        {
            return;
        }
        else if (isNewRoom)
        {
            return;
        }
        segmentparts[i] = replacePrefab;
        segmentImages[i] = replaceImage;
        StartCoroutine(ShowWheel());
    }

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
        // ����Image���
        Image img = segment.GetComponent<Image>();
        // ������ת
        rect.localRotation = Quaternion.Euler(0, 0, -startAngle);
        Button btn = segment.AddComponent<Button>();
        btn.onClick.AddListener(() => OnSegmentClicked?.Invoke(index));
        segmentImages.Add(img);
    }
    public void ClearWheel()
    {
        //�ĳɰ������嶼ɾ���ˣ�
        //foreach (Image img in segmentImages)
        //{
        //    if (img != null && img.gameObject != null)
        //    {
        //        Destroy(img.gameObject);
        //    }
        //}
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        segmentImages.Clear();
    }

    public void UIEnter()
    {
        transform.parent.GetComponent<RectTransform>().DOAnchorPosX(-82.5f, .8f); 
    }
    public void UIExit() 
    {
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
}