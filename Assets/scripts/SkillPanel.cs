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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.instance.currentState == gameManager.GameState.InFight && !exit)
        {
            GetComponent<RectTransform>().DOAnchorPosY(exitY, .5f);
            exit = true;
        }
        if (Input.GetKeyDown(KeyCode.K) && gameManager.instance.currentState != gameManager.GameState.InFight)
        {
            if (exit)
            {
                GetComponent<RectTransform>().DOAnchorPosY(enterY, .5f);
                gameManager.instance.currentState = gameManager.GameState.UIPause;
            }
            else
            {
                GetComponent<RectTransform>().DOAnchorPosY(exitY, .5f);
                gameManager.instance.currentState = gameManager.GameState.Normal;
            }
            exit = !exit;
        }
    }
}
