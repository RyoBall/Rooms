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

    protected override void Start()
    {
        dangerousLevel = 1;
        base.Start();
        //����λ�ô���
        //Instantiate(drink, transform.position, Quaternion.identity);
    }
}
