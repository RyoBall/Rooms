using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIframe : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public Vector2 position;
    public bool unlock;

    public void OnPointerClick(PointerEventData eventData)
    {
        unlock = true;
    }

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
        unlock=false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
