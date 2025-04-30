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
    public List<List<GameObject>> UIframes;
    public List<GameObject> UIframes0; 
    public List<GameObject> UIframes1; 
    public List<GameObject> UIframes2; 
    public List<GameObject> UIframes3; 
    public List<GameObject> UIframes4; 
    public List<GameObject> UIframes5; //test

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        enterY = enterpos.position.y;
        exitY = exitpos.position.y;
        UIframes.Add(UIframes0);
        UIframes.Add(UIframes1);
        UIframes.Add(UIframes2);
        UIframes.Add(UIframes3);
        UIframes.Add(UIframes4);
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
