using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkRoom : RoomBase
{
    public GameObject drink;

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    void Start()
    {
        //λ�ÿɵ�,�Ҿ��ÿ����������ʱ���ÿ�����������
        Instantiate(drink,transform.position,Quaternion.identity);
    }
}
