using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : RoomBase
{
    public GameObject Locker;
    private int lockerNum;


    private void InstantiateLocker(int lockerNum)
    {
        for(int i = 0; i < lockerNum; i++)
        {
            Instantiate(Locker,transform.position, Quaternion.identity);
        }
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 2 / 3;
        base.Start();
        //在一到二之间生成一个数
        lockerNum = Random.Range(1, 3);
        InstantiateLocker(lockerNum);
    }
}
