using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkRoom : RoomBase
{
    public List<GameObject> drink;

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 1/4;
        gameObjects = drink;
        //只有一杯饮料
        drink[0].GetComponent<Drink>().level = level;
        base.Start();
    }
}
