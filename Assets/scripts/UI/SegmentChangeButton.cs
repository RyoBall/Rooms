using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentChangeButton : MonoBehaviour
{
    public static Action ExitAction;
    [SerializeField] private GameObject Bag;
    private RectTransform rect;
    private void Awake()
    {
        ExitAction = null;
    }
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        ExitAction += Exit;
    }
    public void Enter()
    {
        ExitAction?.Invoke();
        Bag.SetActive(true);
        rect.DOAnchorPosX(105, .2f);
    }
    void Exit()
    {
        Bag.SetActive(false);
        rect.DOAnchorPosX(98, .2f);
    }
}
