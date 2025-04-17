using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    public RectTransform exitpos;
    public bool exit;
    public float enterY;
    public float exitY;
    // Start is called before the first frame update
    void Start()
    {
        enterY = GetComponent<RectTransform>().position.y;
        exitY = exitpos.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            if(exit)
            GetComponent<RectTransform>().DOMoveY(enterY,.5f);
            else
            GetComponent<RectTransform>().DOMoveY(exitY,.5f);
            exit = !exit;
        }
    }
}
