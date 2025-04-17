using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lib : RoomBase
{
    public GameObject bookprefab;

    private void InstantiateBook()
    {
        //需要生成书的位置，和策划协商
        //初始数字为0，可能会存在显示问题，可修改
        for(int i = 0; i < 3; i++)
        {
            Instantiate(bookprefab, transform.position, Quaternion.identity).GetComponent<Book>().color = i;
        }
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 1 / 3;
        base.Start();
        InstantiateBook();
    }
}
