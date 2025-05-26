using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public static Bag instance;
    public RectTransform exitpos;
    public RectTransform enterpos;
    public bool exit;
    public float enterY;
    public float exitY;
    public GameObject CurrentBag;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameManager.instance.UIEnter += Enter;
        gameManager.instance.UIExit += Exit;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.instance.currentState == gameManager.GameState.InFight && !exit)
        {
            Exit();
        }
    }
    public void Exit()
    {
        GetComponent<RectTransform>().DOAnchorPosY(exitY, .5f);
    }
    public void Enter()
    {
        GetComponent<RectTransform>().DOAnchorPosY(enterY, .5f);
    }
}
