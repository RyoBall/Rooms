using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class RoomBase : MonoBehaviour
{
    private Vector3 direction;
    public float moveDistance;
    public Transform foggylevel;
    protected bool isfog = false;
    protected bool infog = false;
    protected float dangerousLevel = 0;

    virtual protected void Start()
    {
        foggylevel = enemyGeneratorController.instance.transform;
        if (UnityEngine.Random.value < dangerousLevel)
            isfog = true;
    }
    virtual protected void OnMouseDown()
    {
        gameManager.instance.energy += 5;
        if (!infog)
        {
            if (!isfog)
            {
                Player.instance.targetRoom = transform;
                Player.instance.BeginMove(transform.position);
            }
            else
            {
                foggy();
            }
        }
        else
        {
            intofog();
        }
    }

    private void CheckDirection(Transform transform)
    {
        float x = transform.position.x - Player.instance.currentRoom.transform.position.x;
        float y = transform.position.y - Player.instance.currentRoom.transform.position.y;
        if (x < 0)
        {
            direction = Vector3.left * moveDistance;
        }
        else if (x > 0)
        {
            direction = Vector3.right * moveDistance;
        }
        else if (y < 0)
        {
            direction = Vector3.down * moveDistance;
        }
        else if (y > 0)
        {
            direction = Vector3.up * moveDistance;
        }
    }
    private void foggy()
    {
        infog = true;
        GetComponent<SpriteRenderer>().DOColor(Color.black, .5f);
    }
    private void intofog()
    {
        Player.instance.targetRoom = this.transform;
        Player.instance.transform.DOMove(foggylevel.position, 1);
        enemyGeneratorController.instance.Init();
    }
    public void Removefog() 
    {
        infog = false;
    }

}
