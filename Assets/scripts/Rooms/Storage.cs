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
                AddLockerAndSetLevel(Locker1, level);
                break;
            case 1:
                AddLockerAndSetLevel(Locker2, level);
                AddLockerAndSetLevel(Locker1, level);
                break;
            case 2:
                AddLockerAndSetLevel(Locker2, level);
                AddLockerAndSetLevel(Locker1, level);
                break;
            default:
                break;
        }
        base.Start();
        canUpgrated = true;
    }

    public void AddLockerAndSetLevel(GameObject locker,int level)
    {
        gameObjects.Add(locker);
        locker.GetComponent<Locker>().level = level;
    }
}
