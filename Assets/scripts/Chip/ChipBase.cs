using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 position;
    public bool chosen;
    public bool getin;
    public Vector3 startposition;
    public GameObject packpanel;
    public float factor;
    public UIframe background;
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
        startposition = GetComponent<RectTransform>().position;
        packpanel = transform.parent.gameObject;
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if (chosen)
        {
            GetComponent<RectTransform>().position = Input.mousePosition;
        }
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
        GetComponent<RectTransform>().position = startposition;
    }
}
