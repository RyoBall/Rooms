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
        base.Start();
    }
}
