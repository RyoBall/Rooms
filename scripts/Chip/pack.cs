using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pack : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool chosen;
    public bool getin;
    public Vector3 startposition;
    public RectTransform inposition;
    public GameObject ins;
    public GameObject prefab;
    public GameObject packpanel;
    public void OnPointerDown(PointerEventData eventData)
    {
        chosen = true;
        getin = false;
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        chosen = false;
        GetComponent<Image>().raycastTarget = true;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData,results);
        foreach(var result in results) 
        {
            if (result.gameObject.layer == 6) 
            {
                GetComponent<RectTransform>().position = result.gameObject.GetComponent<RectTransform>().position;
                transform.parent = result.gameObject.transform;
                getin = true;
            }
        }
        if (getin) 
        {
            if(ins==null)
            ins=Instantiate(prefab, Player.instance.transform.position, Quaternion.identity,Player.instance.transform);
        }
        if (!getin) 
        {
            transform.parent = packpanel.transform;
            GetComponent<RectTransform>().position = startposition;
            Destroy(ins);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startposition=GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (chosen)
        {
            GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }
}
