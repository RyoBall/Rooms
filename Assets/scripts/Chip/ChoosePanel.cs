using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChoosePanel : MonoBehaviour
{
    public static ChoosePanel instance;
    public List<GameObject> choice;
    public Action ExitAction;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enter() 
    {
        StartCoroutine(IEnter());
        Blacker.instance.Enter();
        gameManager.instance.currentState = gameManager.GameState.Choosing;
    }
    public void Exit() 
    {
        StartCoroutine(IExit());   
        Blacker.instance.Exit();
        gameManager.instance.currentState = gameManager.GameState.Normal;
    }
    void Afterexit() 
    {
        for(int i = 0; i < choice.Count; i++) 
        {
            Destroy(choice[i]);
        }
        choice.Clear();
        ExitAction.Invoke();
    }
    IEnumerator IEnter (int i=0)
    {
        choice[i].GetComponent<RectTransform>().DOAnchorPosY(-MoveConst.movedistance, MoveConst.movetime);
        yield return new WaitForSeconds(MoveConst.movetime-.3f);
        if (i < choice.Count-1) 
        {
            StartCoroutine(IEnter(i+1));
        }
    }
    IEnumerator IExit(int i = 0) 
    {
        choice[i].GetComponent<RectTransform>().DOAnchorPosY(0,MoveConst.movetime);
        yield return new WaitForSeconds(MoveConst.movetime-.3f);
        if (i < choice.Count - 1)
        {
            StartCoroutine(IExit(i + 1));
        }
        else
            Afterexit();
    }
}
public static class MoveConst 
{
    public static float movetime = .5f;
    public static float movedistance = 500;
}
