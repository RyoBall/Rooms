using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
public class segment : MonoBehaviour
{
    public static segment instance;
    public RectTransform here;
    [Header("��������")]
    public List<float> segmentValues = new List<float> { 1,1,1,1,1,1,1,1,1,1,1,1};
    public List<Color> segmentColors = new List<Color> { Color.red, Color.green, Color.blue, Color.yellow };
    public float wheelRadius = 200f;
    public float padding; // ���μ��
    public Sprite circle;
    public List<GameObject> Rooms = new List<GameObject>();
    [Header("��ǩ����")]
    public bool showLabels = true;
    public Font labelFont;
    public int labelFontSize = 14;
    public Color labelColor = Color.white;
    public float rotatespeed;
    public float rotatespeedm;
    public float downspeed;
    private List<Image> segmentImages = new List<Image>();
    public UnknownRoom targetroom;
    public RectTransform Enter;
    public RectTransform Exit;
    void Start()
    {
        instance = this;
        here = GetComponent<RectTransform>();
        GenerateWheel();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            Startrotate();
        }
        rotatehere();
    }
    private void Startrotate() 
    {
        rotatespeed = rotatespeedm;
        float waittime = rotatespeedm / downspeed;
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
        float totalValue = CalculateTotalValue();
        if (totalValue <= 0) return;

        float currentAngle = 0f;
        for (int i = 0; i < segmentValues.Count; i++)
        {
            float segmentAngle = (segmentValues[i] / totalValue) * 360f;
            CreateSegment(i, currentAngle, segmentAngle);
            currentAngle += segmentAngle;
        }
    }

    float CalculateTotalValue()
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
    }

    void CreateSegment(int index, float startAngle, float angle)
    {
        // ����������Ϸ����
        GameObject segment = new GameObject($"Segment_{index}");
        RectTransform rect = segment.AddComponent<RectTransform>();
        segment.transform.SetParent(transform);
        rect.localPosition = Vector3.zero;
        rect.localRotation = Quaternion.identity;
        rect.sizeDelta = new Vector2(wheelRadius * 2, wheelRadius * 2);

        // ��Ӳ�����Image���
        Image img = segment.AddComponent<Image>();
        segmentpart part=segment.AddComponent<segmentpart>();
        part.room = Rooms[index %Rooms.Count];
        img.sprite = circle;
        img.color = segmentColors[index % segmentColors.Count];
        img.type = Image.Type.Filled;
        img.fillMethod = Image.FillMethod.Radial360;
        img.fillOrigin = 2; // ��ӦImage.Origin360.Top
        img.fillClockwise = true;
        img.fillAmount = (angle - padding) / 360f; // ��ȥ���

        // ������ת
        rect.localRotation = Quaternion.Euler(0, 0, -startAngle);


        segmentImages.Add(img);
    }



    void ClearWheel()
    {
        foreach (Image img in segmentImages)
        {
            if (img != null && img.gameObject != null)
            {
                Destroy(img.gameObject);
            }
        }
        segmentImages.Clear();
    }

    /*public void UpdateSegmentValue(int index, float newValue)
    {
        if (index >= 0 && index < segmentValues.Count)
        {
            segmentValues[index] = newValue;
            GenerateWheel();
        }
    }*/
    public void UIEnter()
    {
        transform.parent.GetComponent<RectTransform>().DOMove(Enter.position, .8f); 
    }
    public void UIExit() 
    {
        transform.parent.GetComponent<RectTransform>().DOMove(Exit.position, .8f); 
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
        segmentImages[((int)here.rotation.z / 30) % 12].GetComponent<segmentpart>().Effect();
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