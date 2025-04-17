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
        //位置可调,我觉得可以做房间的时候用空物体子物体
        Instantiate(drink,transform.position,Quaternion.identity);
    }
}
