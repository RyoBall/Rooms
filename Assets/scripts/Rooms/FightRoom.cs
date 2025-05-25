using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightRoom : RoomBase
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

    public override void ChangeTofoggy()
    {
        ;
    }
}
