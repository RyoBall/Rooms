using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchRoom : RoomBase
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        gameObjects[0].GetComponent<research>().level = level;
        base.Start();
    }
}
