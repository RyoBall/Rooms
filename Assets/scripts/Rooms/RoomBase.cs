using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public interface RoomPosition
{
    Vector2 Position { get; set; }
}
public class RoomBase : MonoBehaviour, RoomPosition
{
    [Header("PlayerMove")]
    private Vector3 direction;

    [Header("FogSet")]
    public Transform foggylevel;
    protected bool isfog = false;
    protected float dangerousLevel = 0;
    [SerializeField] protected bool firstEnter = true;
    [SerializeField] protected List<GameObject> gameObjects;//场景里的互动物
    [SerializeField] protected bool canUpgrated = false;
    public int level = -1;
    public Action EnterAction;
    public int RoomID;
    public bool unlock;
    public Color Startcolor;
    private enum DangerousLevel { none, low, medium, high };
    [SerializeField] private DangerousLevel dangerouslevel;
    [SerializeField]public Vector2 Position { get; set; }

    virtual protected void Start()
    {
        Startcolor = GetComponent<SpriteRenderer>().color;
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
            StartCoroutine(EnterRoutine());
        }
    }
    protected void Dangerouschec()
    {
        switch (dangerouslevel)
        {
            case DangerousLevel.none:
                dangerousLevel = 0;
                break;
            case DangerousLevel.low:
                dangerousLevel = .2f;
                break;
            case DangerousLevel.medium:
                dangerousLevel = .4f;
                break;
            case DangerousLevel.high:
                dangerousLevel = 1f;
                break;
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
        if (Correc(Position.x - Player.instance.currentRoom.GetComponent<RoomBase>().Position.x) + Correc(Position.y - Player.instance.currentRoom.GetComponent<RoomBase>().Position.y) == 1 && gameManager.instance.currentState == gameManager.GameState.Normal)
        {
            if (!isfog)
            {
                StartCoroutine(EnterRoutine());
            }
            else
            {
                StartCoroutine(FogEnterRoutine());
            }
        }
    }

    public static float Correc(float a)
    {
        if (a > 0)
            return a;
        else
            return -a;
    }
    private int CheckDirection()
    {
        float x = transform.position.x - Player.instance.currentRoom.transform.position.x;
        float y = transform.position.y - Player.instance.currentRoom.transform.position.y;
        if (x < 0 || y < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
    public virtual void ChangeTofoggy()
    {
        GetComponent<SpriteRenderer>().DOColor(Color.black, .5f);
    }
    private void intofog()
    {
        Player.instance.targetRoom = transform;
        Player.instance.transform.DOMove(foggylevel.position,.3f);
        enemyGeneratorController.instance.Init();
    }
    public virtual void Removefog()
    {
        isfog = false;
        InitEnvironment();
    }
    IEnumerator FogEnterRoutine()
    {
        Blacker.instance.Enter(1, .5f);
        StartCoroutine(IntoFogRoutine());
        yield return new WaitForSeconds(.8f);
        Blacker.instance.Exit(.5f);
    }
    IEnumerator IntoFogRoutine() 
    {
        yield return new WaitForSeconds(.5f);
        intofog();
    }
    IEnumerator EnterRoutine()
    {
        Player.instance.BeginMove(CheckDirection());
        yield return new WaitForSeconds(Player.instance.moveTime);
        EnterAction.Invoke();
    }
    protected void Enter()
    {
        if (Player.instance.currentRoom != null)
            Player.instance.currentRoom.GetComponent<Collider2D>().enabled = true; //把上一个房间碰撞体激活
        Player.instance.transform.position = transform.position + Vector3.left * Player.instance.movedistance * CheckDirection();
        Player.instance.EndMove(CheckDirection());
        Player.instance.currentRoom = transform;//修改当前房间
        GetComponent<Collider2D>().enabled = false;//把当前房间的碰撞体关闭
        if (firstEnter)
        {
            firstEnter = false;
            Player.instance.energy += 5;
            InitEnvironment();//激活环境
        }
    }
}
