using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class RoomBase : MonoBehaviour
{
    [Header("PlayerMove")]
    private Vector3 direction;
    public float moveDistance;

    [Header("FogSet")]
    public Transform foggylevel;
    protected bool isfog = false;

    protected float dangerousLevel = 0;
    protected bool firstEnter;
    [SerializeField]protected List<GameObject> gameObjects;//场景里的互动物
    [SerializeField] protected bool canUpgrated = false;
    public int level = -1;
    virtual protected void Start()
    {
        foggylevel = enemyGeneratorController.instance.foggylevel;
        if (UnityEngine.Random.value < dangerousLevel)
        {
            isfog = true;
            ChangeTofoggy();
        }
        else 
        {
            InitEnvironment();
        }
    }
    protected virtual void InitEnvironment()
    {
        if (gameObjects != null)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }
    }
    virtual protected void OnMouseDown()
    {
        if (!isfog)
        {
            if(Player.instance.targetRoom!=null)
            Player.instance.targetRoom.GetComponent<Collider2D>().enabled = true;
            Player.instance.targetRoom = transform;
            GetComponent<Collider2D>().enabled = false;
            Player.instance.BeginMove(transform.position);
            if(firstEnter)
            Player.instance.energy += 5;
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
    private void ChangeTofoggy()
    {
        GetComponent<SpriteRenderer>().DOColor(Color.black, .5f);
    }
    private void intofog()
    {
        Player.instance.targetRoom = this.transform;
        Player.instance.transform.DOMove(foggylevel.position, 1);
        enemyGeneratorController.instance.Init();
    }
    public virtual void Removefog()
    {
        isfog = false;
        InitEnvironment();
    }

}
