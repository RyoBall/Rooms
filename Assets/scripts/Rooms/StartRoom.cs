using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : RoomBase
{
    public override void Removefog()
    {
        base.Removefog();
    }

    protected override void InitEnvironment()
    {
        base.InitEnvironment();
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        base.Start();
        Player.instance.transform.position = transform.position;
    }
}
