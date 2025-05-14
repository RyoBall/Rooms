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
    public RectTransform startposition;
    public int startpositioncount;
    public GameObject packpanel;
    public float factor;
    public UIframe background;
    protected RectTransform rectTransform;
    protected Vector2 offset;
    [Header("пео╒")]
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
        chosen = false;
        GetComponent<Image>().raycastTarget = true;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (var result in results)
        {
            if (result.gameObject.layer == GetinChips.UIcaolayer && result.gameObject.GetComponent<UIframe>().unlock && !result.gameObject.GetComponent<UIframe>().getin)
            {
                entereffect(result);
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
        startposition = gameManager.instance.backpacktrans[startpositioncount];
        packpanel = transform.parent.gameObject;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {

    }
    public virtual void entereffect(RaycastResult result)
    {
        background = result.gameObject.GetComponent<UIframe>();
        background.getin = true;
        GetComponent<RectTransform>().position = result.gameObject.GetComponent<RectTransform>().position;
        transform.SetParent(result.gameObject.transform);
        position = result.gameObject.GetComponent<UIframe>().position;
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
        transform.SetParent(packpanel.transform);
        GetComponent<RectTransform>().position = startposition.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
    rectTransform.parent as RectTransform,
    eventData.position,
    eventData.pressEventCamera,
    out Vector2 localPoint))
        {
            rectTransform.localPosition = localPoint+offset;
        }
    }

}
