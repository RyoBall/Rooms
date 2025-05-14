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
    public void Enter() 
    {
        image.DOColor(new Color(0,0,0,.3f),.5f);
    }
    public void Exit() 
    {
        image.DOColor(new Color(0,0,0,0),.5f);
    }
}
