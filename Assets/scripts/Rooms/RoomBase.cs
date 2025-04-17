using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class RoomBase : MonoBehaviour
{
    private Vector3 direction;
    public float moveDistance;

    protected bool isfog = false;
    protected float dangerousLevel = 0;

    virtual protected void Start()
    {
        if(UnityEngine.Random.value < dangerousLevel)
            isfog = true;
    } 
    virtual protected void OnMouseDown()
    {
        gameManager.instance.energy += 5;
        if (!isfog)
        {
            Player.instance.targetRoom = transform;
            CheckDirection(transform);
            Player.instance.BeginMove(direction);
        }else
        {
            //×ªÒÆ³¡¾°
        }
    }

    private void CheckDirection(Transform transform)
    {
        float x = transform.position.x - Player.instance.currentRoom.transform.position.x;
        float y = transform.position.y - Player.instance.currentRoom.transform.position.y;
        if (x < 0)
        {
            direction = Vector3.left*moveDistance;
        }
        else if (x >0)
        {
            direction = Vector3.right*moveDistance;
        }
        else if (y < 0)
        {
            direction = Vector3.down*moveDistance;
        }
        else if (y > 0)
        {
            direction = Vector3.up*moveDistance;
        }
    }
}
