using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [Header("move")]
    public Rigidbody2D rb;
    //public float speed;
    public float moveTime;
    private Animator anim;
    private string animBoolName;
    public Transform currentRoom;
    public Transform targetRoom;
    [Header("shoot")]
    public float cd;
    public float cdm;
    public GameObject bullet;
    [Header("level")]
    public float exp;
    public int level;
    public float levelfactor;
    [Header("State")]
    public float currentSanity;
    public float maxSanity;
    [Header("factor")]
    public float health;
    public float healthm;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        levelup();
    }
    //（
    //void Move()
    //{
    //    rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), speed * Input.GetAxisRaw("Vertical"));
    //}

    #region AnimationAndMove
    public void BeginMove(Vector3 direction)
    {
        //禁用其他操作
        anim.SetBool("beginMove", true);
        transform.DOMove(direction, moveTime).OnComplete(() => EndMove(direction));
    }

    public void EndMove(Vector3 direction)
    {
        anim.SetBool("beginMove", false);
        transform.position = targetRoom.transform.position;
        anim.SetBool("endMove", true);
        transform.DOMove(-direction, moveTime).OnComplete(() => anim.SetBool("endMove", false));
        //恢复控制
    }
    #endregion
    void levelup()
    {
        if (exp >= 10 + level * levelfactor) 
        {
            exp = 0;
            level++;
        }
    }
}
