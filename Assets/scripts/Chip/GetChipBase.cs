using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetChipBase : MonoBehaviour,IPointerClickHandler
{
    public int type;
    public int order;
    public GetChipBase(int type,int order) 
    {
        this.type = type;   
        this.order = order;   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.instance.GetChip(type, order);
        Destroy(gameObject);
    }
}
