using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public static Bag instance;
    public bool exit;
    public float enterY;
    public float exitY;
    public GameObject CurrentBag;
    public int CurrentBagNum;
    public GameObject currentreplacement;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
