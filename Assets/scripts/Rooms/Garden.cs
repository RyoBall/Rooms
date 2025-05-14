using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : RoomBase
{
    public List<GameObject> flowers;


    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 0;
        gameObjects = flowers;
        base.Start();
        //ªÿ∏¥¬˙¿Ì÷«÷µ
    }
}
