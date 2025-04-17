using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : RoomBase
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 1 / 3;
        base.Start();
    }
}
