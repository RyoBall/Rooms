using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Blacker : MonoBehaviour
{
    public Image image;
    public static Blacker instance;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enter(float alpha=.3f,float time=.5f) 
    {
        image.DOColor(new Color(0,0,0,alpha),time);
    }
    public void Exit(float time=.5f) 
    {
        image.DOColor(new Color(0,0,0,0),time);
    }
}
