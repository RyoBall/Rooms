using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Replacement : MonoBehaviour
{
    public GameObject segmentpart;
    public int ID;//所在位置的代号
    public void Click()
    {
        Bag.instance.currentreplacement = gameObject;
        for(int i = 0; i < 12; i++) 
        {
            segment.instance.segmentImages[i].GetComponent<segmentpart>().Clickaction = null;
            segment.instance.segmentImages[i].GetComponent<segmentpart>().Clickaction += ChooseSegment;
            segment.instance.segmentImages[i].GetComponent<segmentpart>().readytoclick();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void ChooseSegment(segmentpart segmentpart) 
    {
        segment.instance.segmentparts[segmentpart.i] = gameManager.instance.Segments[Bag.instance.currentreplacement.GetComponent<Replacement>().segmentpart.GetComponent<segmentpart>().room.GetComponent<RoomBase>().RoomID];
        segment.instance.GenerateWheel();
        gameManager.instance.GetReplacement(gameManager.instance.Segments[segmentpart.room.GetComponent<RoomBase>().RoomID], Bag.instance.currentreplacement.GetComponent<Replacement>().ID);
        Destroy(Bag.instance.currentreplacement);
    }
}
