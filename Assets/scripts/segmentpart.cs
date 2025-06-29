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
    public Action<segmentpart> Clickaction=null;
    public ParticleSystem parti;
    private void Awake()
    {
        gameManager.SegUIExit += Stopclick;
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
        StartCoroutine(SetScale());
    }
    void Update() 
    {
        parti.transform.localScale = new Vector3(Camera.main.orthographicSize / 18, 1, 1);
    }
    IEnumerator SetScale() 
    {
        yield return new WaitForSeconds(0);
        GetComponent<RectTransform>().localScale=Vector3.one;
    }
    public void Effect()
    {
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
        Clickaction?.Invoke(this);
    }
    public void readytoclick() 
    {
        parti.Play();   
    }
    public void Stopclick() 
    {
        if(parti!=null)
        parti.Stop();
    }
}