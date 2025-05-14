using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchRoom : RoomBase
{
    [SerializeField] List<GameObject> researcher;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        dangerousLevel = 1 / 2;
        gameObjects = researcher;
        base.Start();
        
    }
}
