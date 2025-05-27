using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentBag : MonoBehaviour
{
    public static SegmentBag instance;
    public GameObject replacement;
    public List<RectTransform> Positions;
    public int segmentsnum = 0;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
