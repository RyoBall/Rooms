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
    public int islock;
    public bool getin;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Player.instance.unlockpoint > 0&&!unlock) 
        {
            unlock = true;
            Player.instance.unlockpoint -= 1;
            islock = 0;
            GetComponent<Image>().enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().DOColor(new Color(.9f,0, 0, .6f), .15f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().DOColor(new Color(.9f, 0, 0, 1) ,.15f);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
