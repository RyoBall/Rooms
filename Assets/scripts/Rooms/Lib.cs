using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lib : RoomBase
{
    public List<GameObject> bookprefab;

    public void DestroyBook() 
    {
        for(int i = 0; i < bookprefab.Count; i++) 
        {
            Destroy(bookprefab[i]);
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
