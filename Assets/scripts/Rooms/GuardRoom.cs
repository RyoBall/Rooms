using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRoom : RoomBase
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 1;
        base.Start();
    }
}
