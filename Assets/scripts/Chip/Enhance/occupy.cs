using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class occupy : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public UIframe background;
    public bulletEnhanceBase dad;

    public void OnPointerDown(PointerEventData eventData)
    {
        dad.OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dad.OnPointerUp(eventData);
    }

    // Start is called before the first frame update
    void Start()
    {
        dad = GetComponentInParent<bulletEnhanceBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
