using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lib : RoomBase
{
    public GameObject bookprefab;

    private void InstantiateBook()
    {
        //��Ҫ�������λ�ã��Ͳ߻�Э��
        //��ʼ����Ϊ0�����ܻ������ʾ���⣬���޸�
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
