using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : RoomBase
{
    public List<GameObject> Locker;
    private int lockerNum;


    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 1 / 2;
        gameObjects = Locker;
        base.Start();

    }
}
