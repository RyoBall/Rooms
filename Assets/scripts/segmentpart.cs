using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using UnityEngine.EventSystems;
using System;

public class segmentpart : MonoBehaviour, IPointerClickHandler
{
    public RectTransform targetUI; // Ҫ����Ŀ��UI
    public GameObject room;
    public int i;
    public Action<segmentpart> Clickaction=null;
    private void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
    }
    void Update() 
    {
        ;
    }
    public void Effect()
    {
        Debug.Log("enterpos");
        GameObject ins = Instantiate(room, segment.instance.targetroom.transform.position, Quaternion.identity);
        ins.GetComponent<RoomBase>().Position = segment.instance.targetroom.GetComponent<RoomPosition>().Position;
        Destroy(segment.instance.targetroom.gameObject);
        //���¿��Ƿ���segment��
        segment.instance.targetroom = null;
        segment.instance.UIExit();
        gameManager.instance.currentState = gameManager.GameState.Normal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clickaction?.Invoke(this);
    }
}