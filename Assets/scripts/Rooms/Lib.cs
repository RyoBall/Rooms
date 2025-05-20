using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lib : RoomBase
{
    public void DestroyBook() 
    {
        for(int i = 0; i < gameObjects.Count; i++) 
        {
            Destroy(gameObjects[i]);
        }
    }


    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 1 / 4;
        base.Start();
    }
}
