using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorPanel : MonoBehaviour
{
    public float EnterX;
    public float ExitX;
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        gameManager.SegUIEnter += Enter;
        gameManager.SegUIExit += Exit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Enter() 
    {
        rect.DOAnchorPosX(EnterX, .5f);
    }
    void Exit() 
    {
        rect.DOAnchorPosX(ExitX, .5f);
    }
}
