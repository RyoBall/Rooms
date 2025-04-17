using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : RoomBase
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    void Start()
    {
        //ªÿ∏¥¬˙¿Ì÷«÷µ
        Player.instance.currentSanity = Player.instance.maxSanity;
    }
}
