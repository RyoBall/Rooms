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
    public float moveDistance;

    [Header("FogSet")]
    public Transform foggylevel;
    protected bool isfog = false;
    protected float dangerousLevel = 0;
    [SerializeField]protected bool firstEnter=true;
    [SerializeField] protected List<GameObject> gameObjects;//������Ļ�����
    [SerializeField] protected bool canUpgrated = false;
    public int level = -1;
    public Action EnterAction;
    public int RoomID;
    public bool unlock;
    private enum DangerousLevel {none,low,medium,high };
    [SerializeField]private DangerousLevel dangerouslevel;
    public Vector2 Position { get; set; }

    virtual protected void Start()
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
            EnterAction.Invoke();
        }
    }
    void Dangerouschec() 
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
        if (Correc(Position.x - Player.instance.currentRoom.GetComponent<RoomBase>().Position.x) + Correc(Position.y - Player.instance.currentRoom.GetComponent<RoomBase>().Position.y) <= 1&&gameManager.instance.currentState==gameManager.GameState.Normal)
        {
            if (firstEnter)
            {
                Player.instance.energy += 5;
                firstEnter = false;
            }
            if (!isfog)
            {
                EnterAction.Invoke();
            }
            else
            {
                intofog();
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
    public virtual void ChangeTofoggy()
    {
        GetComponent<SpriteRenderer>().DOColor(Color.black, .5f);
    }
    private void intofog()
    {
        Player.instance.targetRoom = transform;
        Player.instance.transform.DOMove(foggylevel.position, 1);
        enemyGeneratorController.instance.Init();
    }
    public virtual void Removefog()
    {
        isfog = false;
        InitEnvironment();
    }
    protected void Enter()
    {
        if (Player.instance.currentRoom != null)
            Player.instance.currentRoom.GetComponent<Collider2D>().enabled = true; //����һ��������ײ�弤��
        Player.instance.currentRoom = transform;//�޸ĵ�ǰ����
        GetComponent<Collider2D>().enabled = false;//�ѵ�ǰ�������ײ��ر�
        Player.instance.BeginMove(transform.position);//������˹�ȥ
        if (firstEnter) 
        {
            firstEnter = false;
            InitEnvironment();//�����
        }
    }
}
