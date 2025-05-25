using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using UnityEngine.EventSystems;

public class segmentpart : MonoBehaviour,IPointerClickHandler
{
    public RectTransform targetUI; // 要检测的目标UI
    public GameObject room;
    public int i;

    public void Effect() 
    {
        Debug.Log("enterpos");
        Debug.Log(i);
        GameObject ins=Instantiate(room, segment.instance.targetroom.transform.position, Quaternion.identity);
        ins.GetComponent<RoomBase>().Position=segment.instance.targetroom.GetComponent<RoomPosition>().Position;
        Destroy(segment.instance.targetroom.gameObject);
        //以下考虑放在segment里
        segment.instance.targetroom = null;
        segment.instance.UIExit();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}