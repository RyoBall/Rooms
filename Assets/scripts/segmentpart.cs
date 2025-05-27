using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using UnityEngine.EventSystems;
using System;

public class segmentpart : MonoBehaviour, IPointerClickHandler
{
    public RectTransform targetUI; // 要检测的目标UI
    public GameObject room;
    public int i;
    public Action Clickaction;
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
        //以下考虑放在segment里
        segment.instance.targetroom = null;
        segment.instance.UIExit();
        gameManager.instance.currentState = gameManager.GameState.Normal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Bag.instance.currentreplacement != null)
        {
            segment.instance.segmentparts[i] = gameManager.instance.Segments[Bag.instance.currentreplacement.GetComponent<Replacement>().segmentpart.GetComponent<segmentpart>().room.GetComponent<RoomBase>().RoomID];
            segment.instance.GenerateWheel();
            gameManager.instance.GetReplacement(gameManager.instance.Segments[room.GetComponent<RoomBase>().RoomID], Bag.instance.currentreplacement.GetComponent<Replacement>().ID);
            Destroy(Bag.instance.currentreplacement);
        }
        
    }
}