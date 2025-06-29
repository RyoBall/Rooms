using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathImage : MonoBehaviour
{
    public static DeathImage instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enter() 
    {
        GetComponent<RectTransform>().DOAnchorPosY(0, .2f);
    }
}
