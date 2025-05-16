using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : RoomBase
{
    //public List<GameObject> Locker;
    public GameObject Locker1;
    public GameObject Locker2;
    private int lockerNum;


    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 1 / 2;
        switch (level)
        {
            case 0:
                gameObjects.Add(Locker1);
                Locker1.GetComponent<Locker1>().level = level;
                break;


        }
        base.Start();
        canUpgrated = true;
    }
}
