using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    public static SkillPanel instance;
    public RectTransform exitpos;
    public RectTransform enterpos;
    public bool exit;
    public float enterY;
    public float exitY;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager.instance.UIEnter += Enter;
        gameManager.instance.UIExit += Exit;
    }

    // Update is called once per frame
    void Update()
    {
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
