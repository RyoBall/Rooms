using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Replacement : MonoBehaviour
{
    public GameObject segmentpart;
    public int ID;//����λ�õĴ���
    public void Click()
    {
        Bag.instance.currentreplacement = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
