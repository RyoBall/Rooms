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
            GetComponent<Image>().DOColor(new Color(0, 0, 0, .8f), .3f); 
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().DOColor(new Color(.5f*islock,0, 0, .8f), .3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().DOColor(new Color(.5f * islock, 0, 0, .4f), .3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        unlock=false;
        islock = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
