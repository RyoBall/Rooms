using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler,IPointerEnterHandler,IPointerExitHandler
{
    public Vector2 position;
    public bool chosen;
    public bool getin;
    public Transform StartPosition;
    private GameObject BagPanel;//芯片背包
    private UIframe background;//嵌入后的背景
    protected RectTransform rectTransform;
    private AudioSource player;
    [Header("信息")]
    public string chipname;
    public string description;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        player.clip = gameManager.instance.exitclip;
        player.Play();
        if (getin)
        {
            exiteffect();
        }
        chosen = true;
        getin = false;
        GetComponent<Image>().raycastTarget = false;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
rectTransform.parent as RectTransform,
eventData.position,
eventData.pressEventCamera,
out Vector2 localPoint))
        {
            rectTransform.localPosition = localPoint;
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        //bool AlreadyGetin = false;//是否已经找到对应的背景（防止背景重叠导致同时触发多个背景）
        chosen = false;
        GetComponent<Image>().raycastTarget = true;
        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(eventData.position));
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.layer == GetinChips.UIcaolayer && hit.collider.gameObject.GetComponent<UIframe>().unlock && !hit.collider.gameObject.GetComponent<UIframe>().getin)
            {
                entereffect(hit.collider.gameObject);
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
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        BagPanel = Bag.instance.gameObject;
        rectTransform = GetComponent<RectTransform>();
        player = GetComponent<AudioSource>();
        player.volume = .15f;
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
        if (gameManager.instance.initfinish)
        {
            player.clip = gameManager.instance.enterclip;
            player.Play();
        }
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
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
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



    public virtual void OnPointerExit(PointerEventData eventData)
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        NameTex.instance.TMP_Text.text = chipname;
        DescriptionTex.instance.TMP_Text.text = description;
    }
}
