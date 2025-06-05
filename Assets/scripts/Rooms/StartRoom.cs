using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : RoomBase
{
    public override void Removefog()
    {
        base.Removefog();
    }

    protected override void InitEnvironment()
    {
        base.InitEnvironment();
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void Start()
    {
        Dangerouschec();
        EnterAction += Enter;
        foggylevel = enemyGeneratorController.instance.foggylevel;
        if (UnityEngine.Random.value < dangerousLevel)
        {
            isfog = true;
            ChangeTofoggy();
        }
        else
        {
            Player.instance.transform.position = transform.position;
        }
        Player.instance.transform.position = transform.position;
        Player.instance.currentRoom = transform;
        GetComponent<Collider2D>().enabled = false;
    }
}
