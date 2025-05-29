using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkRoom : RoomBase
{

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        gameObjects[0].GetComponent<Drink>().level = level;
        base.Start();
    }
}
