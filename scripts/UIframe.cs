using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIframe : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().DOColor(new Color(.5f, .5f, .5f, .8f), .3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().DOColor(new Color(.5f, .5f, .5f, .4f), .3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
