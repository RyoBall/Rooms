using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacementBag : MonoBehaviour
{
    public static ReplacementBag instance;
    public List<SegmentBag> segmentBags;
    public int segmentsnum;
    public bool exit;
    public float enterY;
    public float exitY;
    public GameObject CurrentBag;
    public int CurrentBagNum;
    public GameObject currentreplacement;
    public GameObject replacement;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager.SegUIEnter += Enter;
        gameManager.SegUIExit += Exit;
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
