using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool chosen;
    public bool getin;
    public Vector3 startposition;
    public GameObject packpanel;
    public LayerMask UIPanellayer;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
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
            if (result.gameObject.layer == UIPanellayer)
            {
                GetComponent<RectTransform>().position = result.gameObject.GetComponent<RectTransform>().position;
                transform.parent = result.gameObject.transform;
                getin = true;
            }
        }
        if (getin)
        {
            entereffect();
        }
        if (!getin)
        {
            exiteffect();
        }
        
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        startposition = GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if (chosen)
        {
            GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }
    public virtual void entereffect() 
    {
        
    }
    public virtual void exiteffect() 
    {
        transform.parent = packpanel.transform;
        GetComponent<RectTransform>().position = startposition;
    }
}
