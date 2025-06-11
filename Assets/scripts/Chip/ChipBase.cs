using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Vector2 position;
    public bool chosen;
    public bool getin;
    public Transform StartPosition;
    private int startpositioncount;//��ʼλ��ID
    private GameObject BagPanel;//оƬ����
    private UIframe background;//Ƕ���ı���
    protected RectTransform rectTransform;
    [Header("��Ϣ")]
    public string chipname;
    public string description;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (getin)
        {
            exiteffect();
        }
        chosen = true;
        getin = false;
        GetComponent<Image>().raycastTarget = false;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        bool AlreadyGetin = false;//�Ƿ��Ѿ��ҵ���Ӧ�ı�������ֹ�����ص�����ͬʱ�������������
        chosen = false;
        GetComponent<Image>().raycastTarget = true;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (var result in results)
        {
            if (result.gameObject.layer == GetinChips.UIcaolayer && result.gameObject.GetComponent<UIframe>().unlock && !result.gameObject.GetComponent<UIframe>().getin&&!AlreadyGetin)
            {
                AlreadyGetin = true;
                entereffect(result.gameObject);
            }
        }
        if (!getin)
        {
            returnposition();
        }
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        StartPosition = gameManager.instance.backpacktrans[startpositioncount];
        BagPanel = Bag.instance.gameObject;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {

    }
    public virtual void entereffect(GameObject BackGround)
    {
        background = BackGround.GetComponent<UIframe>();
        BackGround.GetComponent<RectTransform>().SetAsLastSibling();
        background.getin = true;
        GetComponent<RectTransform>().position = BackGround.GetComponent<RectTransform>().position;
        transform.SetParent(BackGround.transform);
        position = BackGround.GetComponent<UIframe>().position;
        getin = true;
        GetinChips.instance.chips.Add(this);
    }
    public virtual void exiteffect()
    {
        GetinChips.instance.chips.Remove(this);
        background.getin = false;
        background = null;
    }
    public void returnposition()
    {
        transform.SetParent(StartPosition);
        GetComponent<RectTransform>().anchoredPosition=Vector2.zero;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
    rectTransform.parent as RectTransform,
    eventData.position,
    eventData.pressEventCamera,
    out Vector2 localPoint))
        {
            rectTransform.localPosition = localPoint;
        }
    }

}
