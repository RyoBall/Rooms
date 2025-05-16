using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(RectTransform))]
public class segment : MonoBehaviour
{
    public static segment instance;
    public RectTransform here;
    [Header("��������")]
    public const int segmentcount = 12;
    public List<GameObject> segmentparts = new List<GameObject>();
    private List<Image> segmentImages = new List<Image>();
    [Header("��ǩ����")]
    public bool showLabels = true;
    public Font labelFont;
    public int labelFontSize = 14;
    public Color labelColor = Color.white;
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
            Button btn = gameObject.AddComponent<Button>();
            btn.onClick.AddListener(() => OnSegmentClicked?.Invoke(i));

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
        // ����������Ϸ����
        /*GameObject segment = new GameObject($"Segment_{index}");
        RectTransform rect = segment.AddComponent<RectTransform>();
        segment.transform.SetParent(transform);
        rect.localPosition = Vector3.zero;
        rect.localRotation = Quaternion.identity;
        rect.sizeDelta = new Vector2(wheelRadius * 2, wheelRadius * 2);*/
        GameObject segment = Instantiate(segmentparts[index % segmentparts.Count], transform.position, Quaternion.identity);
        segment.transform.SetParent(transform);
        segment.GetComponent<segmentpart>().i=index;
        RectTransform rect = segment.GetComponent<RectTransform>();
        // ����Image���
        Image img = segment.GetComponent<Image>();
        // ������ת
        rect.localRotation = Quaternion.Euler(0, 0, -startAngle);
        segmentImages.Add(img);
        /*img.type = Image.Type.Filled;
        img.fillMethod = Image.FillMethod.Radial360;
        img.fillOrigin = 2; // ��ӦImage.Origin360.Top
        img.fillClockwise = true;
        img.fillAmount = (angle - padding) / 360f; // ��ȥ���*/ //����image

    }





    void ClearWheel()
    {
        //�ĳɰ������嶼ɾ���ˣ�
        //foreach (Image img in segmentImages)
        //{
        //    if (img != null && img.gameObject != null)
        //    {
        //        Destroy(img.gameObject);
        //    }
        //}
        //segmentImages.Clear();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void UIEnter()
    {
        transform.parent.GetComponent<RectTransform>().DOAnchorPosX(-82.5f, .8f); 
    }
    public void UIExit() 
    {
        transform.parent.GetComponent<RectTransform>().DOAnchorPosX(82.5f, .8f); 
    }
    /*public void UpdateSegmentValue(int index, float newValue)
    {
        if (index >= 0 && index < segmentValues.Count)
        {
            segmentValues[index] = newValue;
            GenerateWheel();
        }
    }*/
    /*float CalculateTotalValue()
    {
        float total = 0f;
        foreach (float value in segmentValues)
        {
            if (value < 0)
            {
                Debug.LogWarning("Segment value cannot be negative. Using absolute value.");
                total += Mathf.Abs(value);
            }
            else
            {
                total += value;
            }
        }
        return total;
    }*/

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
    /*private void partEffect()
    {
        Debug.Log("enterpos");
        Destroy(segment.instance.targetroom.gameObject);
        Instantiate(room, segment.instance.targetroom.transform.position, Quaternion.identity);
        segment.instance.targetroom = null;
        segment.instance.UIExit();
    }*/
}