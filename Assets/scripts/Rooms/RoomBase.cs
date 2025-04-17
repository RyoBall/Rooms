using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class RoomBase : MonoBehaviour
{
    private Vector3 direction;
    public float moveDistance;
    virtual protected void OnMouseDown()
    {
        Player.instance.targetRoom = transform;
        CheckDirection(transform);
        Player.instance.BeginMove(direction);
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
